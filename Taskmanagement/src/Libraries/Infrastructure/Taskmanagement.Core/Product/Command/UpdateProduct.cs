using AutoMapper;
using MediatR;
using Taskmanagement.Repositories.Interface;
using Taskmanagement.Services.Model;

namespace Taskmanagement.Core.Product.Command;

public record UpdateCustomer(int Id, VmProduct Vmproduct) : IRequest<VmProduct>;

public class UpdateProductHandler : IRequestHandler<UpdateCustomer, VmProduct>
{
    private readonly IProductRepository _productRepository;

    private readonly IMapper _mapper;

    //dependency injection
    public UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<VmProduct> Handle(UpdateCustomer request, CancellationToken cancellationtoken)
    {
        var data = _mapper.Map<Model.Product>(request.Vmproduct);
        return await _productRepository.Update(request.Id, data);
    }


}

