using DupperFundamental.Entitiy_Framework__EF_.Entities;
using DupperFundamental.Entitiy_Framework__EF_.Repositories;

namespace DupperFundamental.Entitiy_Framework__EF_.Services;

public class PurchaseService : IPurchaseService
{
    private readonly IRepository<Purchase> _repository;
    private readonly IPersistence _persistence;
    private readonly IProductService _productService;

    public PurchaseService(IRepository<Purchase> repository, IPersistence persistence, IProductService productService)
    {
        _repository = repository;
        _persistence = persistence;
        _productService = productService;
    }

    public Purchase CreateNewPurchase(Purchase purchase)
    {
        _persistence.BeginTransaction();
        try
        {
            var newPurchase = _repository.Save(purchase);
            _persistence.SaveChanges();
            
            foreach (var purchaseDetail in newPurchase.PurchaseDetails)
            {
                var product = _productService.GetById(purchaseDetail.ProductId.ToString());
                product.stock -= purchaseDetail.Qty;
            }
            _persistence.SaveChanges();
            _persistence.Commit();
            return newPurchase;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _persistence.Rollback();
            throw;
        }
    }
}