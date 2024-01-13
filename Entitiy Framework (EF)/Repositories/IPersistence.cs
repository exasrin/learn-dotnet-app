namespace DupperFundamental.Entitiy_Framework__EF_.Repositories;

public interface IPersistence
{
    void SaveChanges();
    void BeginTransaction();
    void Commit();
    void Rollback();
}