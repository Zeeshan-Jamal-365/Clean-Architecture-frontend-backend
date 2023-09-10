using AutoMapper;
using MediatR;
using Taskmanagement.Repositories.Interface;
using Taskmanagement.Services.Model;

namespace Taskmanagement.Core.Product.Command;

public record CreateProduct(VmProduct Vmproduct) : IRequest<VmProduct>;

public class CreateProductHandler : IRequestHandler<CreateProduct, VmProduct>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;


    //dependency injection
    public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<VmProduct> Handle(CreateProduct request, CancellationToken cancellationtoken)
    {
        var data = _mapper.Map<Model.Product>(request.Vmproduct);
        return await _productRepository.Add(data);
    }


}

