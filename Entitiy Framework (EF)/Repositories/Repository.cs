namespace DupperFundamental.Entitiy_Framework__EF_.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    // readonly -> tidak bisa dubah /reassign
    private readonly AppDbContext _appDbContext;

    public Repository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public TEntity Save(TEntity entity)
    {
        var entry = _appDbContext.Set<TEntity>().Add(entity);
        return entry.Entity;
    }

    public TEntity? FindById(Guid id)
    {
        return _appDbContext.Set<TEntity>().Find(id);
    }

    public TEntity? FindBy(Func<TEntity, bool> predicate)
    {
        return _appDbContext.Set<TEntity>().FirstOrDefault(predicate);
    }

    public IEnumerable<TEntity> FindAll()
    {
        return _appDbContext.Set<TEntity>().AsEnumerable();
    }

    public IEnumerable<TEntity> FinAll(Func<TEntity, bool> predicate)
    {
        return _appDbContext.Set<TEntity>().Where(predicate);
    }

    public void Update(TEntity entity)
    {
        _appDbContext.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _appDbContext.Set<TEntity>().Remove(entity);
    }
}