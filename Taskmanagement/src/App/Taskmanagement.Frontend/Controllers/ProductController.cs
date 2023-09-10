using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Taskmanagement.Frontend.Models;

namespace Taskmanagement.Frontend.Controllers;
public class ProductController : Controller
{

    private readonly HttpClient _httpClient;

    public ProductController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("TaskmanagementApi");
    }





    public async Task<List<Product>> GetAllProduct()
    {
        var data = await _httpClient.GetFromJsonAsync<List<Product>>("Product");
        return data is not null ? data : new List<Product>();
    }

    // GET: ProductController/Details/5
    public async Task<IActionResult> Index()
    {
        var data = await GetAllProduct();
        return View(data);
    }



    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {

        if (id == 0)
        {
            var CustomerResponse = await _httpClient.GetAsync("Customer");
            if (CustomerResponse.IsSuccessStatusCode)
            {
                var content = await CustomerResponse.Content.ReadAsStringAsync();
                var CustomerList = JsonConvert.DeserializeObject<List<Customer>>(content);
                ViewData["CustomerId"] = new SelectList(CustomerList, "Id", "CustomerName");
            }

            return View(new Product());
        }
        else
        {
            var CustomerResponse = await _httpClient.GetAsync("Customer");
            if (CustomerResponse.IsSuccessStatusCode)
            {
                var content = await CustomerResponse.Content.ReadAsStringAsync();
                var CustomerList = JsonConvert.DeserializeObject<List<Customer>>(content);
                ViewData["CustomerId"] = new SelectList(CustomerList, "Id", "CustomerName");
            }

            var ProductResponse = await _httpClient.GetAsync($"Product/{id}");
            if (ProductResponse.IsSuccessStatusCode)
            {
                var newData = await ProductResponse.Content.ReadFromJsonAsync<Product>();
                return View(newData);
            }
            else
            {
                return NotFound();
            }
        }

    }


    [HttpPost, ValidateAntiForgeryToken]

    public async Task<IActionResult> AddorEdit(int id, Product product)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                var ProductResponse = await _httpClient.PostAsJsonAsync("Product", product);
                if (ProductResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create product");
                    return View(product);
                }
            }
            else
            {
                //update Data
                if (id != product.Id)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var ProductResponse = await _httpClient.PutAsJsonAsync($"Product/{id}", product);

                    if (ProductResponse.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to update the State.");
                        return View(product);
                    }
                }
                return View(product);
            }

        }
        return View(new Product());
    }



    // POST: ProductController/Delete/5

    public async Task<IActionResult> Delete(int id)
    {
        var ProductResponse = await _httpClient.DeleteAsync($"Product/{id}");
        if (ProductResponse.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return NotFound();
        }
    }
}
