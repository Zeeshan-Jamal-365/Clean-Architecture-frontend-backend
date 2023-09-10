using MediatR;
using Taskmanagement.Repositories.Interface;
using Taskmanagement.Services.Model;

namespace Taskmanagement.Core.Customer.Command;

public record DeleteCustomer(int Id) : IRequest<VmCustomer>;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomer, VmCustomer>
{
    private readonly ICustomerRepository _customerRepository;



    //dependency injection
    public DeleteCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;

    }

    public async Task<VmCustomer> Handle(DeleteCustomer request, CancellationToken cancellationtoken)
    {

        return await _customerRepository.Delete(request.Id);
    }


}

