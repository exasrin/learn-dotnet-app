using DupperFundamental.Entitiy_Framework__EF_.Entities;
using DupperFundamental.Entitiy_Framework__EF_.Repositories;

namespace DupperFundamental.Entitiy_Framework__EF_.Services;

public interface IPurchaseService
{
    Purchase CreateNewPurchase(Purchase purchase);
}