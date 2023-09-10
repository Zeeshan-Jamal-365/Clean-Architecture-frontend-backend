using MediatR;
using Microsoft.AspNetCore.Mvc;
using Taskmanagement.Core.Product.Command;
using Taskmanagement.Core.Product.Query;
using Taskmanagement.Services.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taskmanagement.Backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{

    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // GET: api/<ProductController>
    [HttpGet]
    public async Task<ActionResult<VmProduct>> Get()
    {
        var data = await _mediator.Send(new GetAllCustomerQuery());
        return Ok(data);
    }

    // GET api/<ProductController>/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<VmProduct>> Get(int id)
    {
        var data = await _mediator.Send(new GetCustomerById(id));
        return Ok(data);
    }

    // POST api/<ProductController>
    [HttpPost]
    public async Task<ActionResult<VmProduct>> Post([FromBody] VmProduct Vmproduct)
    {
        var data = await _mediator.Send(new CreateProduct(Vmproduct));
        return Ok(data);
    }

    // PUT api/<ProductController>/5
    [HttpPut("{id:int}")]
    public async Task<ActionResult<VmProduct>> Put(int id, [FromBody] VmProduct Vmproduct)
    {
        var data = await _mediator.Send(new UpdateCustomer(id, Vmproduct));
        return Ok(data);
    }

    // DELETE api/<ProductController>/5
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<VmProduct>> Delete(int id)
    {
        var data = await _mediator.Send(new DeleteCustomer(id));
        return Ok(data);
    }
}
