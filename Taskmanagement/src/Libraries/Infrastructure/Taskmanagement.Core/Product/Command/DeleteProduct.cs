using MediatR;
using Taskmanagement.Repositories.Interface;
using Taskmanagement.Services.Model;

namespace Taskmanagement.Core.Product.Command;

public record DeleteCustomer(int Id) : IRequest<VmProduct>;

public class DeleteProductHandler : IRequestHandler<DeleteCustomer, VmProduct>
{
    private readonly IProductRepository _productRepository;



    //dependency injection
    public DeleteProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;

    }

    public async Task<VmProduct> Handle(DeleteCustomer request, CancellationToken cancellationtoken)
    {

        return await _productRepository.Delete(request.Id);
    }


}

