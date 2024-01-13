using DupperFundamental.Dupper;

namespace DupperFundamental.Linq;

public class Program
{
    public void Main(string[] args)
    {
        /*
         * LINQ -> Language Integrated Query
         * LINQ ini mendukung banyak data source
         * - In memory object (List, Array)
         * - ADO.NET (DataSet)
         * - Entity Manager
         * - SQL Framework
         * - XML Doucument
         * - Data source dan lain-lain
         *
         * Linq Providers
         * - LINQ to Objects
         * - LINQ to entities
         * - LINQ to XML
         * - LINQ to Sql
         * - LINQ to DataSet
         */
        
        /*
         * 3 hal untuk membuat query LINQ
         * - Data source (SQL, In Memory Object, XML)
         * - Query (SELECT blablabla)
         * - Execution of the query
         *
         * Kombinasi query yang perlu kita kethui
         * - Query syntax
         * - Mwthod syntax
         * - Mixed syntax
         */
        
        // =================== Query Syntax ===================
        /*
         * from object to datasource    -> Inisialisasi
         * where condition              -> Kondisi
         * select object                -> seleksi
         */
        
        // List Example
        // var numbers = new List<int>{1,2,3,4,5,6,7,8,9,10};
        // var querySyntax =
        //     from number in numbers
        //     where number > 5
        //     select number;
        //
        // foreach (var i in querySyntax)
        // {
        //     Console.WriteLine(i);
        // }
        
        // Object example
        // var products = new List<Product>
        // {
        //     new() { Id = 1, ProductName = "Hoodie", ProductPrice = 120000, Stock = 10 },
        //     new() { Id = 1, ProductName = "Kemeja", ProductPrice = 150000, Stock = 10 },
        //     new() { Id = 1, ProductName = "Celana", ProductPrice = 100000, Stock = 10 },
        //     new() { Id = 1, ProductName = "Sepatu", ProductPrice = 200000, Stock = 10 },
        // };
        // var querySyntaxProduct = 
        //     from product in products 
        //     where product.ProductPrice > 100000 
        //     select product.ProductName;
        // foreach (var product in querySyntaxProduct)
        // {
        //     Console.WriteLine(product);
        // }


        // =================== Method Syntax ===================
        /*
         * Datasource.ConditionMethod().SelectionMethod()
         * inisialisasi -- kondisi   --  seleksi
         */
        
        // List example
        // var numbers = new List<int>{1,2,3,4,5,6,7,8,9,10};
        // var evenNumbers = numbers.Where(number => number % 2 == 0).OrderByDescending(i => i);
        //
        // foreach (var evenNumber in evenNumbers)
        // {
        //  Console.WriteLine(evenNumber);
        // }
        
        // Object example
        // var products = new List<Product>
        // {
        //     new() { Id = 1, ProductName = "Hoodie", ProductPrice = 120000, Stock = 10 },
        //     new() { Id = 1, ProductName = "Kemeja", ProductPrice = 150000, Stock = 10 },
        //     new() { Id = 1, ProductName = "Celana", ProductPrice = 100000, Stock = 10 },
        //     new() { Id = 1, ProductName = "Sepatu", ProductPrice = 200000, Stock = 10 },
        // };
        // var methodSyntaxProduct = products.Where(product => product.ProductPrice > 100000).Select(product => product.ProductName);
        // foreach (var product in methodSyntaxProduct)
        // {
        //     Console.WriteLine(product);
        // }
        
        // Pagination example
        // var products = new List<Product>
        // {
        //     new() { Id = 1, ProductName = "Hoodie", ProductPrice = 120000, Stock = 10 },
        //     new() { Id = 2, ProductName = "Kemeja", ProductPrice = 150000, Stock = 10 },
        //     new() { Id = 3, ProductName = "Celana", ProductPrice = 100000, Stock = 10 },
        //     new() { Id = 4, ProductName = "Sepatu", ProductPrice = 200000, Stock = 10 },
        // };
        // var page = 1;
        // var size = 2;
        //
        // var productPage = products.Skip((page - 1) * size).Take(size);
        // Console.WriteLine($"Page: {page}");
        // foreach (var product in productPage)
        // {
        //     Console.WriteLine(product);
        // }
        
        
        // =================== Mixed Syntax ===================
        // campuran antara query syntax dan method syntax
        // var products = new List<Product>
        // {
        //     new() { Id = 1, ProductName = "Hoodie", ProductPrice = 100000, Stock = 10 },
        //     new() { Id = 2, ProductName = "Kemeja", ProductPrice = 150000, Stock = 10 },
        //     new() { Id = 3, ProductName = "Celana", ProductPrice = 100000, Stock = 10 },
        //     new() { Id = 4, ProductName = "Sepatu", ProductPrice = 200000, Stock = 10 },
        // };
        //
        // var mixedSyntaxProducts =
        //     (from product in products 
        //         where product.ProductPrice is > 100000 and < 250000 
        //         select product).OrderByDescending(p => p.ProductName);
        //
        // foreach (var product in mixedSyntaxProducts)
        // {
        //     Console.WriteLine(product);
        // }
        
        // =================== Extension Method ===================
        // Penerapan extension method
        int a = 10;
        a.Plus(10);
        
        // Penerapan extension method untuk pagination
        var products = new List<Product>
        {
            new() { Id = 1, ProductName = "Hoodie", ProductPrice = 120000, Stock = 10 },
            new() { Id = 2, ProductName = "Kemeja", ProductPrice = 150000, Stock = 10 },
            new() { Id = 3, ProductName = "Celana", ProductPrice = 100000, Stock = 10 },
            new() { Id = 4, ProductName = "Sepatu", ProductPrice = 200000, Stock = 10 },
        };
        var page = 1;
        var size = 2;
        
        var productPage = products.Page(page, size);
        Console.WriteLine($"Page: {page}");
        foreach (var product in productPage)
        {
            Console.WriteLine(product);
        }
    }
}

// Extension method -> untuk menambahkan method di library/codingan orang
public static class MyExtensionMethod
{
    public static int Plus(this int value, int parameter)
    {
        return value + parameter;
    }

    public static IEnumerable<T> Page<T>(this IEnumerable<T> dataSource, int page, int size)
    {
        return dataSource.Skip((page - 1) * size).Take(size);
    }
}
