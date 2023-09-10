using System.Linq.Expressions;
using Taskmanagement.Shared.Common;

namespace Taskmanagement.Shared.CommonRepository;
public interface IRepository<TEntity, IModel, T>
    where TEntity : class, IEntity<T>, new()
    where IModel : class, IVm<T>
    where T : IEquatable<T>
{
    public Task<IModel> GetById(T Id);
    public Task<IEnumerable<IModel>> GetList();

    public Task<List<IModel>> GetList(params Expression<Func<TEntity, object>>[] includes);
    public Task<IModel> Delete(T Id);
    public Task<IModel> Update(T Id, TEntity entity);
    public Task<IModel> Add(TEntity entity);

}
