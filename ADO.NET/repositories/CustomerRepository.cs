using System.Data.SqlClient;
using DupperFundamental.ADO.NET.models;

namespace DupperFundamental.ADO.NET.repositories;

public class CustomerRepository : ICustomerRepository
{
    public readonly SqlConnection? _sqlConnection;

    public CustomerRepository(string connectionString)
    {
        _sqlConnection = new SqlConnection(connectionString);
    }

    public void GenerateTable()
    {
        try
        {
            _sqlConnection.Open();
            Console.WriteLine("Database connected succesfully");
            
            SqlCommand command = new SqlCommand(@"CREATE TABLE m_customer(
                id INT PRIMARY KEY,
                name VARCHAR(48),
                phone_number VARCHAR(14),
                is_active bit
            )", _sqlConnection);

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
            _sqlConnection?.Close();
        }
    }

    public void Save(Customer customer)
    {
        try
        {
            _sqlConnection.Open();
            // string query = @"INSERT INTO m_customer (id, name, phone_number, is_active)
            //                 VALUES (1, 'Asrin', '081234455', 'true')";

            string query = @"INSERT INTO m_customer (id, name, phone_number, is_active)
                           VALUES (@id, @name, @phone_number, 'true')";
            
            var command = new SqlCommand(query, _sqlConnection);
            command.Parameters.AddWithValue("@id", customer.Id);
            command.Parameters.AddWithValue("@name", customer.Name);
            command.Parameters.AddWithValue("@phone_number", customer.PhoneNumber);
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
            _sqlConnection.Close();
        }
    }

    public Customer? FindById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Customer> FindAll()
    {
        var customers = new List<Customer>();
        try
        {
            _sqlConnection.Open();
            const string query = "SELECT * FROM m_customer";
            var command = new SqlCommand(query, _sqlConnection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                customers.Add(new Customer
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Name = reader["name"].ToString(),
                    PhoneNumber = reader["phone_number"].ToString(),
                    IsActive = Convert.ToBoolean(reader["is_active"])
                });
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            _sqlConnection.Close();
        }

        return customers;
    }

    public void Update(Customer customer)
    {
        throw new NotImplementedException();
    }

    public void DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}