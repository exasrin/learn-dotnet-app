using DupperFundamental.Entitiy_Framework__EF_.Entities;
using Microsoft.EntityFrameworkCore;

namespace DupperFundamental.Entitiy_Framework__EF_.Repositories;

public class AppDbContext: DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;User=sa;Password=200800Alfaathir;Database=enigma_shop;TrustServerCertificate=True");
        
        // dotnet tool install --global dotnet-ef -> untuk migrasi dari entity ke database
        // dotnet ef migrations add InitialCreate -> buat migrations
        // dotnet ef database update -> melakukan update miragtion/ update database
        
    }
}