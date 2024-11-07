using HW_11.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace HW_11.Dapper
{
    public class DapperRepository : IDapperRepository
    {
        // رشته اتصال ثابت
        private string connectionString = @"Server=DESKTOP-SJNEDPF\SQLEXPRESS;Database=ShopDb;User Id=sa;Password=Nimak1640;TrustServerCertificate=True;";

        public int Add(Product product)
        {
            try
            {
                string query = "INSERT INTO Products (Name, Price, CategoryId) OUTPUT INSERTED.Id VALUES (@Name, @Price, @CategoryId)";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    int insertedId = connection.ExecuteScalar<int>(query, new { product.Name, product.Price, product.Category.Id });
                    return insertedId;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public List<Product> GetAll()
        {
            try
            {
                string query = "SELECT p.Id, p.Name, p.Price, c.Name AS CategoryName FROM Products p JOIN Categories c ON p.CategoryId = c.Id";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var products = connection.Query<Product>(query).AsList();
                    connection.Close();
                    return products;
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Product GetById(int id)
        {
            try
            {
                string query = "SELECT p.Id, p.Name, p.Price, c.Name AS CategoryName FROM Products p JOIN Categories c ON p.CategoryId = c.Id WHERE p.Id = @Id";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var product = connection.QuerySingleOrDefault<Product>(query, new { Id = id });
                    connection.Close();
                    return product;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Update(Product product)
        {
            try
            {
                string query = "UPDATE Products SET Name = @Name, Price = @Price, CategoryId = @CategoryId WHERE Id = @Id";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    int rowsAffected = connection.Execute(query, new
                    {
                        product.Name,
                        product.Price,
                        CategoryId = product.Category.Id,
                        product.Id
                    });
                    connection.Close();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                string query = "DELETE FROM Products WHERE Id = @Id";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    int rowsAffected = connection.Execute(query, new { Id = id });
                    connection.Close();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}