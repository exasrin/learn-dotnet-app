namespace DupperFundamental.Entitiy_Framework__EF_.Repositories;

public class DbPersistence : IPersistence
{
    private readonly AppDbContext _appDbContext;

    public DbPersistence(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void SaveChanges()
    {
        _appDbContext.SaveChanges();
    }

    public void BeginTransaction()
    {
        _appDbContext.Database.BeginTransaction();
    }

    public void Commit()
    {
        _appDbContext.Database.CommitTransaction();
    }

    public void Rollback()
    {
        _appDbContext.Database.RollbackTransaction();
    }
}