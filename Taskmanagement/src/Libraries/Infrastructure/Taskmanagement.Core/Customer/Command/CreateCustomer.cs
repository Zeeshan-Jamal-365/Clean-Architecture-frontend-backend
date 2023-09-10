using AutoMapper;
using MediatR;
using Taskmanagement.Repositories.Interface;
using Taskmanagement.Services.Model;

namespace Taskmanagement.Core.Customer.Command;

public record CreateCustomer(VmCustomer Vmcustomer) : IRequest<VmCustomer>;

public class CreateCustomerHandler : IRequestHandler<CreateCustomer, VmCustomer>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;


    //dependency injection
    public CreateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<VmCustomer> Handle(CreateCustomer request, CancellationToken cancellationtoken)
    {
        var data = _mapper.Map<Model.Customer>(request.Vmcustomer);
        return await _customerRepository.Add(data);
    }


}

