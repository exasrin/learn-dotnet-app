using DupperFundamental.Entitiy_Framework__EF_.Entities;
using DupperFundamental.Entitiy_Framework__EF_.Repositories;
using DupperFundamental.Entitiy_Framework__EF_.Services;
using Microsoft.EntityFrameworkCore;

namespace DupperFundamental.Entitiy_Framework__EF_;

public class Program
{
    public static void Main(string[] args)
    {
        AppDbContext context = new();
        IRepository<Purchase> repository = new Repository<Purchase>(context);
        IRepository<Product> productRepository = new Repository<Product>(context);
        IPersistence persistence = new DbPersistence(context);
        IProductService productService = new ProductService(productRepository, persistence);
        IPurchaseService purchaseService = new PurchaseService(repository, persistence, productService);

        var purchase = new Purchase
        {
            TrancDate = DateTime.Now,
            CustomerId = Guid.Parse("63bab275-9c31-4c5e-9ac9-08dc10a14c96"),
            PurchaseDetails = new List<PurchaseDetail>
            {
                new() { ProductId = Guid.Parse("682ea962-de0e-4e5b-e7db-08dc109fe10d"), Qty = 2, },
                new() { ProductId = Guid.Parse("e176db26-4c58-4a18-e7dc-08dc109fe10d"), Qty = 1, },
            }
        };
        purchaseService.CreateNewPurchase(purchase);
    }

    private static void TransactionQuery()
    {
        AppDbContext context = new();
        IRepository<Customer> customerRepository = new Repository<Customer>(context);
        IRepository<Product> productRepository = new Repository<Product>(context);

        var purchase = context.Purchases
            // .Include(purchase => purchase.Customer)      -> cara pertama untuk melakukan join
            .Include("Customer")                            // -> cara kedua dengan syarat nama parameternya harus sama dengan nama properti join yang ada di objectnya
            .Include("PurchaseDetails")
            // .ThenInclude(pd => pd.Product)               // -> cara pertama
            .Include(("PurchaseDetails.Product"))           // -> cara kedua
            .FirstOrDefault(p => p.Id.Equals(Guid.Parse("2a1c82ff-5864-4b7b-ef03-08dc10a31970")));
        Console.WriteLine(purchase);

        /*var transaction = context.Database.BeginTransaction();

        try
        {
            // buat data untuk transaksi dan lakukan save ke database
            // sehingga database bisa terupdate dana dapat melakukan update
            // data stock

            var purchase = new Purchase
            {
                TrancDate = DateTime.Now,
                CustomerId = Guid.Parse("63bab275-9c31-4c5e-9ac9-08dc10a14c96"),
                PurchaseDetails = new List<PurchaseDetail>
                {
                    new() { ProductId = Guid.Parse("682ea962-de0e-4e5b-e7db-08dc109fe10d"), Qty = 2, },
                    new() { ProductId = Guid.Parse("e176db26-4c58-4a18-e7dc-08dc109fe10d"), Qty = 1, },
                }
            };
            context.Add(purchase);
            context.SaveChanges();

            // untuk melakukan update maka harus diselect dan looping dulu berdasarkan id
            // shingga dapat diupdate
            foreach (var purchaseDetail in purchase.PurchaseDetails)
            {
                var product = context.Products.FirstOrDefault(product => product.Id.Equals(purchaseDetail.ProductId));
                if (product != null) product.stock -= purchaseDetail.Qty;
            }

            context.SaveChanges();
            transaction.Commit();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            transaction.Rollback();
            throw;
        }   */
    }

    private static void CrudWithRepository()
    {
        AppDbContext context = new();
        IRepository<Customer> repository = new Repository<Customer>(context);

        Customer customer = new Customer
        {
            CustomerName = "Sulaiaman",
            Address = "Oheo",
            PhoneNumber = "0812343",
            email = "alfaathir@test.com"
        };

        // =============== create =============== 
        repository.Save(customer);

        // =============== Find By Id =============== 
        // var customer = repository.FindById(Guid.Parse("b4a24e6d-98b2-486d-1da3-08dc0e60cc16"));

        // =============== Find By Name =============== 
        // var customer = repository.FindBy(c => c.Address.Equals("Alfaathir"));
        // Console.WriteLine(customer.CustomerName);

        // =============== Delete =============== 
        // repository.Delete(customer);
    }

    private static void CrudOperationEntityFramework()
    {
        /*
         * Microsoft.EntityFrameworkCore
         * Microsoft.EntityFrameworkCore.Tools
         * Microsoft.EntityFrameworkCore.SqlServer
         * Microsoft.EntityFrameworkCore.Design -> Digunakan saat menggunakan dependncy injection
         */
        
        /*
         * Change Tracker
         * Added -> penanda saat di insert ke database tapi belum terinsert
         * Detached -> Entity jejaknya dicopot
         * Unchanged
         * Modified
         * Deleted
         */

        using AppDbContext context = new();
        
        // ====================== create ====================== 
        // Customer customer = new Customer
        // {
        //     CustomerName = "Asrin",
        //     Address = "Konawe",
        //     PhoneNumber = "081223323",
        //     email = "asrin@gmail.com"
        // };
        // context.Add(customer);
        // Console.WriteLine(context.Entry(customer).State);
        // context.SaveChanges();
        
        
        // ====================== Get All ====================== 
        var customers = context.Customers.ToList();
        foreach (var customer in customers)
        {
            Console.WriteLine($"Customer: {customer.Id}, Name: {customer.CustomerName}, " +
                              $"Phone Number: {customer.PhoneNumber}, Email: {customer.email}");
        }
        
        
        // ====================== Get By Id ====================== 
        // var customer = context.Customers.FirstOrDefault((customer => customer.Id.Equals(1)));
        // Console.WriteLine($"Customer: ID: {customer.Id}, Name: {customer.CustomerName}, " +
        //                   $"Phone Number: {customer.PhoneNumber}, Email: {customer.email}");// Get By Id
        
        
        // ====================== Get By Name ====================== 
        // var customer = context.Customers.FirstOrDefault(customer => customer.CustomerName.ToLower().Equals("Rasyid".ToLower()));
        // Console.WriteLine($"Customer: ID: {customer.Id}, Name: {customer.CustomerName}, " +
        //                   $"Phone Number: {customer.PhoneNumber}, Email: {customer.email}");
        
        
        // ====================== Update ====================== 
        // Customer newCustomer = new()
        // {
        //     Id = 4,
        //     CustomerName = "Rasyid",
        //     Address = "Oheo",
        //     PhoneNumber = "08123456",
        //     email = "oheo@gmail.com"
        // };
        // context.Update(newCustomer);
        // context.SaveChanges();
        
        
        // ====================== Delete ====================== 
        // untuk delete harus di get dulu sehingga bisa untuk didelete
        // context.Customers.Remove(customer);
        // context.SaveChanges();
    }
}