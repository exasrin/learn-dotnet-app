using System.Data.SqlClient;
using DupperFundamental.ADO.NET.models;
using DupperFundamental.ADO.NET.repositories;

namespace DupperFundamental.ADO.NET;

public class Program
{
    public void Main(string[] args)
    {
        // ADO.NET sama seperti JDBC di java yaitu untuk menghubungkan program ke database
        // ADO.NET itu library/dependencies, package manager di C# adalah nugget
        /*
         * connection -> digunakan untuk mengoneksikan database dengan spesifik driver
         * command -> digunakan untuk mengeksekusi operasi query
         * Data Reader -> digunakan untuk membaca data yang ada di database 
         */
        

        // const string localhost = "server=localhost,1433";
        // const string user = "sa";
        // const string password = "200800Alfaathir";
        // const string database = "tokonyadia";
        //
        // const string connectionString = $"{localhost};{user};{password};{database};";
        
        const string connectionString = "data source=localhost,1433;user=sa;password=200800Alfaathir;database=tokonyadia;";
        // SqlConnection connect = new SqlConnection(connectionString);
        ICustomerRepository customerRepository = new CustomerRepository(connectionString);
        // customerRepository.Save(new Customer
        // {
        //     Id = 3,
        //     Name = "Rasyid",
        //     PhoneNumber = "098678768",
        // });
        
        customerRepository.FindAll().ForEach(Console.WriteLine);

    }

    private static void SelectCustomer(SqlConnection connect)
    {
        try
        {
            connect.Open();
            string query = "SELECT * FROM m_customer WHERE id = @id";
            var command = new SqlCommand(query, connect);
            command.Parameters.AddWithValue("@id", 1);

            var dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
                Console.WriteLine($"id: {dataReader.GetInt32(0)}, name: {dataReader.GetString(1)}, " +
                                  $"phoneNumber: {dataReader.GetString(2)}, isActive: {dataReader.GetBoolean(3)}");
            }
            else
            {
                Console.WriteLine("Customer Not Found");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            connect.Close();
        }
    }

    private static void SaveCustomer(SqlConnection connect)
    {
        try
        {
            connect.Open();
            // string query = @"INSERT INTO m_customer (id, name, phone_number, is_active)
            //                 VALUES (1, 'Asrin', '081234455', 'true')";

            string query = @"INSERT INTO m_customer (id, name, phone_number, is_active)
                           VALUES (@id, @name, @phone_number, 'true')";
            var id = int.Parse(Console.ReadLine());
            var name = Console.ReadLine();
            var phoneNumber = Console.ReadLine();
            
            var command = new SqlCommand(query, connect);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@phone_number", phoneNumber);
            command.ExecuteNonQuery();
            
            Console.WriteLine("Customer created successfully");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            connect.Close();
        }
    }

    private static void CreatedTableCustomer(SqlConnection connect)
    {
        try
        {
            // // cara 1
            // SqlConnection connect = new SqlConnection(connectionString);
            // connect.Open();
            // Console.WriteLine("Database connected succesfully");
            // connect.Close();

            // // cara 2
            // using (var connect = new SqlConnection(connectionString))
            // {
            //     connect.Open();
            // }

            // Pakai cara yang pertama yang best practice
            connect.Open();
            Console.WriteLine("Database connected succesfully");
            
            SqlCommand command = new SqlCommand(@"CREATE TABLE m_customer(
                id INT PRIMARY KEY,
                name VARCHAR(48),
                phone_number VARCHAR(14),
                is_active bit
            )", connect);

            command.ExecuteNonQuery();
            Console.WriteLine("Table m_customer created successfully");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            connect?.Close();
        }
    }
}