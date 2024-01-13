using DupperFundamental.ADO.NET.models;

namespace DupperFundamental.Entitiy_Framework__EF_.Services;

public interface ICustomerService
{
    Customer CreateNewCustomer(Customer customer);
    Customer GetById(string id);
}