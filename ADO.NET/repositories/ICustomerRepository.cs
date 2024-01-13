using DupperFundamental.ADO.NET.models;

namespace DupperFundamental.ADO.NET.repositories;

public interface ICustomerRepository
{
    void GenerateTable();
    void Save(Customer customer);
    Customer? FindById(int id);
    List<Customer> FindAll();
    void Update(Customer customer);
    void DeleteById(int id);
    
}