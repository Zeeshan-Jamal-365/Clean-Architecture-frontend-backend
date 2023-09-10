using MediatR;
using Taskmanagement.Repositories.Interface;
using Taskmanagement.Services.Model;

namespace Taskmanagement.Core.Product.Query;

public record GetCustomerById(int Id) : IRequest<VmProduct>;

public class GetProductByIdHandler : IRequestHandler<GetCustomerById, VmProduct>
{
    private readonly IProductRepository _productRepository;

    //dependency injection
    public GetProductByIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<VmProduct> Handle(GetCustomerById request, CancellationToken cancellationtoken)
    {
        return await _productRepository.GetById(request.Id);
    }


}

