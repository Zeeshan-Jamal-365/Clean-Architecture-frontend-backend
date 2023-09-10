using AutoMapper;
using MediatR;
using Taskmanagement.Repositories.Interface;
using Taskmanagement.Services.Model;

namespace Taskmanagement.Core.Product.Query;

public record GetAllCustomerQuery() : IRequest<IEnumerable<VmProduct>>;

public class GetAllProductQueryHandler : IRequestHandler<GetAllCustomerQuery, IEnumerable<VmProduct>>
{
    private readonly IProductRepository _productRepository;

    //dependency injection
    public GetAllProductQueryHandler(IProductRepository productRepository,IMapper mapper)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<VmProduct>> Handle(GetAllCustomerQuery request, CancellationToken cancellationtoken)
    {
        var result = await _productRepository.GetList(x => x.Customer);
        return result;
    }


}

