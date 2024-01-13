using DupperFundamental.Entitiy_Framework__EF_.Entities;
using DupperFundamental.Entitiy_Framework__EF_.Repositories;

namespace DupperFundamental.Entitiy_Framework__EF_.Services;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _repository;
    private readonly IPersistence _persistence;

    public ProductService(IRepository<Product> repository, IPersistence persistence)
    {
        _repository = repository;
        _persistence = persistence;
    }

    public Product CreateNewProduct(Product product)
    {
        try
        {
            var newProduct = _repository.Save(product);
            _persistence.SaveChanges();
            return newProduct;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Product GetById(string id)
    {
        try
        {
            var product = _repository.FindById(Guid.Parse(id));
            if (product is null) throw new Exception("product not found");
            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}