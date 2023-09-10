using Microsoft.AspNetCore.Mvc;
using Taskmanagement.Frontend.Models;

namespace Taskmanagement.Frontend.Controllers;
public class CustomerController : Controller
{
    private readonly HttpClient _httpClient;

    public CustomerController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("TaskmanagementApi");

    }

    public async Task<List<Customer>> GetAllCustomer()
    {
        var data = await _httpClient.GetFromJsonAsync<List<Customer>>("Customer");
        return data is not null ? data : new List<Customer>();
    }
    public async Task<IActionResult> Index()
    {
        var data = await GetAllCustomer();
        return View(data);
    }
    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        if (id == 0)
        {
            return View(new Customer());
        }
        else
        {
            var response = await _httpClient.GetAsync($"Customer/{id}");
            if (response.IsSuccessStatusCode)
            {
                var customers = await response.Content.ReadFromJsonAsync<Customer>();
                return View(customers);
            }
            else
            {
                return NotFound();
            }
        }
    }


    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AddorEdit(Customer customer, int id)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                var data = await _httpClient.PostAsJsonAsync("Customer", customer);
                if (data.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                //Update
                if (id != customer.Id)
                {
                    return BadRequest();

                }
                if (ModelState.IsValid)
                {
                    var response = await _httpClient.PutAsJsonAsync($"Customer/{id}", customer);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to update the Customer.");
                        return View(customer);
                    }
                }
                return View(customer);


            }



        }
        return View(new Customer());
    }







    public async Task<ActionResult> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"Customer/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return NotFound();
        }
    }
}

