using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using InventoryManagementSystem_SQL.Model;

namespace InventoryManagementSystem
{
    public class DBOperations : SqlServerDatabaseInitializer, IProduct
    {
        public async Task AddProductAsync(Product newProduct)
        {
            var query = ProductCommands.InsertProduct();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using var sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@Name", newProduct.Name);
                sqlCommand.Parameters.AddWithValue("@Price", newProduct.Price);
                sqlCommand.Parameters.AddWithValue("@Quantity", newProduct.Quantity);
                await sqlCommand.ExecuteNonQueryAsync();
            }
        }

        public async Task EditProductNameAsync(string oldName, string newName)
        {
            var query = ProductCommands.UpdateProductName();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using var sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@OldName", oldName);
                sqlCommand.Parameters.AddWithValue("@NewName", newName);
                await sqlCommand.ExecuteNonQueryAsync();
            }
        }

        public async Task EditProductPriceAsync(string productName, decimal newPrice)
        {
            var query = ProductCommands.UpdateProductPrice();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using var sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@ProductName", productName);
                sqlCommand.Parameters.AddWithValue("@NewPrice", newPrice);
                await sqlCommand.ExecuteNonQueryAsync();
            }
        }

        public async Task EditProductQuantityAsync(string productName, int newQuantity)
        {
            var query = ProductCommands.UpdateProductQuantity();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using var sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@ProductName", productName);
                sqlCommand.Parameters.AddWithValue("@NewQuantity", newQuantity);
                await sqlCommand.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteProductAsync(string productName)
        {
            var query = ProductCommands.DeleteProduct();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using var sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@ProductName", productName);
                await sqlCommand.ExecuteNonQueryAsync();
            }
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var query = ProductQueries.GetAllProducts();
            var products = new List<Product>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using var sqlCommand = new SqlCommand(query, connection);
                using var productsDataReader = await sqlCommand.ExecuteReaderAsync();

                while (productsDataReader.Read())
                {
                    products.Add(GetProductFromString(productsDataReader));
                }
            }

            return products;
        }

        public async Task<bool> IsEmptyAsync()
        {
            var query = ProductQueries.IsEmpty();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using var sqlCommand = new SqlCommand(query, connection);
                using var productsDataReader = await sqlCommand.ExecuteReaderAsync();

                return !productsDataReader.HasRows;
            }
        }

        private static Product GetProductFromString(SqlDataReader productsDataReader)
        {
            var name = productsDataReader.GetString(0);
            var price = (decimal)productsDataReader.GetDouble(1);
            var quantity = productsDataReader.GetInt32(2);

            return new Product(name, price, quantity);
        }
    }
}
