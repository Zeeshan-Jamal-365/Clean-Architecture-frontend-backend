using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Taskmanagement.Shared.Common;
using Taskmanagement.Shared.Extensions;

namespace Taskmanagement.Shared.CommonRepository;
public abstract class RepositoryBase<TEntity, IModel, T> : IRepository<TEntity, IModel, T>
        where TEntity : class, IEntity<T>, new()
    where IModel : class, IVm<T>
    where T : IEquatable<T>
{

    private readonly IMapper _mapper;
    private readonly DbContext _dbContext;


    protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();
    public RepositoryBase(IMapper mapper, DbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;

    }




    public async Task<IModel> Add(TEntity entity)
    {
        DbSet.Add(entity);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<IModel>(entity);
    }

    public async Task<IModel> Delete(T Id)
    {
        var entity = await DbSet.FindAsync(Id) ?? throw new InvalidOperationException("Data not found");
        DbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<IModel>(entity);

    }

    public async Task<IModel> GetById(T Id)
    {
        var data = await DbSet.FindAsync(Id);
        return _mapper.Map<IModel>(data);
    }


    public Task<IEnumerable<IModel>> GetList()
    {
        var data = DbSet.AsEnumerable();
        var models = _mapper.Map<IEnumerable<IModel>>(data);
        return Task.FromResult(models);
    }



    public async Task<List<IModel>> GetList(params Expression<Func<TEntity, object>>[] includes)
    {
        var entities = await includes.Aggregate(_dbContext.Set<TEntity>().AsQueryable(),(current, include)=> current.Include(include)).ToListAsync().ConfigureAwait(true);
        return _mapper.Map<List<IModel>>(entities);
    }

    public async Task<IModel> Update(T Id, TEntity entity)
    {
        var temp = await DbSet.FindAsync(Id);
        if (temp != null)
        {
            entity.Copy(temp);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<IModel>(temp);
        }
        throw new ArgumentNullException();

    }
}
