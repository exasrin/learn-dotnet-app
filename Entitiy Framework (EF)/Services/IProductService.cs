using DupperFundamental.Entitiy_Framework__EF_.Entities;

namespace DupperFundamental.Entitiy_Framework__EF_.Services;

public interface IProductService
{
    Product CreateNewProduct(Product product);
    Product GetById(string id);
}