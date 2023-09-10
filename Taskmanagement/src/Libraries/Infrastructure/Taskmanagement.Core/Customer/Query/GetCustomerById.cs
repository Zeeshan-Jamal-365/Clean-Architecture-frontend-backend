using MediatR;
using Taskmanagement.Repositories.Interface;
using Taskmanagement.Services.Model;

namespace Taskmanagement.Core.Customer.Query;

public record GetCustomerById(int Id) : IRequest<VmCustomer>;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerById, VmCustomer>
{
    private readonly ICustomerRepository _customerRepository;

    //dependency injection
    public GetCustomerByIdHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<VmCustomer> Handle(GetCustomerById request, CancellationToken cancellationtoken)
    {
        return await _customerRepository.GetById(request.Id);
    }


}

