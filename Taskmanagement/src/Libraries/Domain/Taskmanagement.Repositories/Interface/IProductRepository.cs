using Taskmanagement.Model;
using Taskmanagement.Services.Model;
using Taskmanagement.Shared.CommonRepository;

namespace Taskmanagement.Repositories.Interface;
public interface IProductRepository : IRepository<Product, VmProduct, int>
{
}
