namespace DupperFundamental.Entitiy_Framework__EF_.Repositories;

public interface IRepository<TEntity>
{
    TEntity Save(TEntity entity);
    TEntity? FindById(Guid id);
    TEntity? FindBy(Func<TEntity, bool> predicate);
    IEnumerable<TEntity> FindAll();
    IEnumerable<TEntity> FinAll(Func<TEntity, bool> predicate);
    void Update(TEntity entity);
    void Delete(TEntity entity);
} 