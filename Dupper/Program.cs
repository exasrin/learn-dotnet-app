using System.Data.SqlClient;
using Dapper;

namespace DupperFundamental.Dupper;

public class Program
{
    public void Main(string[] args)
    {
        /*
         * Dapper adalah ORM (micro orm) yang memungkinkan kita untuk mengakses data lebih cepat
         * dan memapping object
         *
         * Keunggulan dupper
         * - dapper ringan dan cepat
         * - dapper ini mudah digunakan dna object mapping yang powerfull
         * - dapper mendukung yang namanya parameterized queries yang membantu kita untuk menghindari yang namanya sql injection
         *
         * Tujuan utamanya memappung object
         *
         * Dupper RDBMS (Provider): SQL Server, Oracle, PostgresSql, MySql
         *
         * Extensiont method: membuat function/method didalam sutu class tanpa merubah isi dari class tersbut
         */
        
        // Implementasi dari IDBConnection
        
        /*
         * 4 method extension IDBConnection
         * - Query (DDL)
         * - Execute (DDL, DML)
         * - ExecuteScalar (DML, DQL) -> mengembalikan satu record dan satu column
         * - ExecuteReader (DQL)
         */
        
        // menggunakan using auto close connection
        using var connection = new SqlConnection("server=localhost,1433;user=sa;password=200800Alfaathir;database=enigma_shop");
        DefaultTypeMap.MatchNamesWithUnderscores = true; // -> apapun yang dimapping pascal case itu bisa diambil sehingga datanya bisa terbaca
        
        // var query = @"
        //     CREATE TABLE m_product (
        //         id int identity primary key,
        //         product_name varchar(100),
        //         product_price bigint,
        //         stock int
        //     )";
        
        // ========================== Example Execute ==========================
        // var query = "INSERT INTO m_product (product_name, product_price, stock) VALUES ('Thumbler', 100000, 30)";
        // connection.Execute(query);

        // ========================== Example Query ==========================
        // // Menampilkan multiple data
        // var query = "SELECT * FROM m_product";
        // // var products = connection.Query(query).ToList(); // -> kalau tidak menggunakan generic data terbaca tapi tidak dimapping 
        // var products = connection.Query<Product>(query).ToList(); // -> kalau tidak menggunakan generic data terbaca tapi tidak dimapping 
        // foreach (var product in products)
        // {
        //     Console.WriteLine(product);
        // }

        /*
         * Menampilkan single data
         * - QuerySingle - Dynamic              = Mengembalikan satu data berupa dynamic -> Exception saatu query kosong atau data bisa lebih dari satu
         * - QuerySingle<T>
         * - QuerySingleOrDefault -Dynamic      = Mengembalikan satu data berupa dynamic -> Exception saatu lebih dari satu kalau query kosong akan return null
         * - QuerySingleOrDefault<T>
         * - QueryFirst - Dynamic               = Mengembalikan satu data berupa dynamic -> Exception saatu query itu kosong
         * - QueryFirst<T>
         * - QueryFirstOrDefault - Dynamic      = Mengembalikan satu data berupa dynamic -> Tidak mengembalikan exception apapun, kalau query kosong akan return null
         * - QueryFirstOrDefault<T>
         */
        // var query = "SELECT * FROM m_product WHERE id = 1";
        // var product = connection.QueryFirstOrDefault<Product>(query);
        // Console.WriteLine(product);

        // ========================== Example ExecuteScalar ==========================
        // var query = "SELECT COUNT(id) FROM m_product";
        // var count = connection.ExecuteScalar<int>(query);
        // Console.WriteLine(count);


        // ========================== Example ExecuteReader ==========================
        // var query = "SELECT * FROM m_product";
        // var reader = connection.ExecuteReader(query);
        //
        // while (reader.Read())
        // {
        //     Console.WriteLine(new Product
        //     {
        //         Id = Convert.ToInt32(reader["id"]),
        //         ProductName = reader["product_name"].ToString(),
        //         ProductPrice = Convert.ToInt64(reader["product_price"]),
        //         Stock = Convert.ToInt32(reader["stock"])
        //     });
        // }
        
        
        // ========================== Parameterized Dapper ==========================
        /*
         * Parameterize Dapper -> SQL server itu menggunakan @
         * - Anonymous Paramters
         * - Dynamic Parameters
         */

        var product = new Product
        {
         ProductName = "Mouse",
         ProductPrice = 50000,
         Stock = 10
        };

        // ========================== Anonymous parameter with anonymous object ==========================
        var productParams = new
        {
         productName = product.ProductName,
         productPrice = product.ProductPrice,
         stock = product.Stock
        };
        // var query =
        //  "INSERT INTO m_product (product_name, product_price, stock) VALUES (@productname, @productPrice, @stock)";
        // connection.Execute(query, productParams);
        // Console.WriteLine("create new product is successfully");
        
        // ========================== Dynamic Parameters ==========================
        // cara 1
        // menggunakan class DynamicParameters yang akan menjadi parameter kedua di Execute()
        // var dynamicParams = new DynamicParameters(product);
        // var query =
        //  "INSERT INTO m_product (product_name, product_price, stock) VALUES (@productname, @productPrice, @stock)";
        // connection.Execute(query, dynamicParams);
        // Console.WriteLine("create new product is successfully");
        
        
        // cara 2
        // langsung menggunakan objectnya yang akan menjadi parameter kedua di Execute()
        // var query =
        //  "INSERT INTO m_product (product_name, product_price, stock) VALUES (@productname, @productPrice, @stock)";
        // connection.Execute(query, product);
        // Console.WriteLine("create new product is successfully");
        
        // Teknik lain
        var query = "SELECT * FROM m_product WHERE product_price > @productPrice AND stock > @stock";
        var products = connection.Query<Product>(query, new
        {
         productPrice = 100000,
         stock = 5
        }).ToList();
        products.ForEach(Console.WriteLine);
    }
}