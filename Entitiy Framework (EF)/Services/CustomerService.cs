using DupperFundamental.ADO.NET.models;
using DupperFundamental.Entitiy_Framework__EF_.Repositories;

namespace DupperFundamental.Entitiy_Framework__EF_.Services;

public class CustomerService : ICustomerService
{
    private readonly IRepository<Customer> _repository;
    private readonly IPersistence _persistance;

    public CustomerService(IRepository<Customer> repository, IPersistence persistance)
    {
        _repository = repository;
        _persistance = persistance;
    }

    public Customer CreateNewCustomer(Customer customer)
    {
        try
        {
            var newCustomer = _repository.Save(customer);
            _persistance.SaveChanges();
            return newCustomer;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Customer GetById(string id)
    {
        var customer = _repository.FindById(Guid.Parse(id));
        if (customer is null) throw new Exception("cutomer not found");
        return customer;
    }
}