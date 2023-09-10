using MediatR;
using Microsoft.AspNetCore.Mvc;
using Taskmanagement.Core.Customer.Command;
using Taskmanagement.Core.Customer.Query;
using Taskmanagement.Services.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taskmanagement.Backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{

    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // GET: api/<CustomerController>
    [HttpGet]
    public async Task<ActionResult<VmCustomer>> Get()
    {
        var data = await _mediator.Send(new GetAllCustomerQuery());
        return Ok(data);
    }

    // GET api/<CustomerController>/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<VmCustomer>> Get(int id)
    {
        var data = await _mediator.Send(new GetCustomerById(id));
        return Ok(data);
    }

    // POST api/<CustomerController>
    [HttpPost]
    public async Task<ActionResult<VmCustomer>> Post([FromBody] VmCustomer Vmcustomer)
    {
        var data = await _mediator.Send(new CreateCustomer(Vmcustomer));
        return Ok(data);
    }

    // PUT api/<CustomerController>/5
    [HttpPut("{id:int}")]
    public async Task<ActionResult<VmCustomer>> Put(int id, [FromBody] VmCustomer Vmcustomer)
    {
        var data = await _mediator.Send(new UpdateCustomer(id, Vmcustomer));
        return Ok(data);
    }

    // DELETE api/<CustomerController>/5
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<VmCustomer>> Delete(int id)
    {
        var data = await _mediator.Send(new DeleteCustomer(id));
        return Ok(data);
    }
}
