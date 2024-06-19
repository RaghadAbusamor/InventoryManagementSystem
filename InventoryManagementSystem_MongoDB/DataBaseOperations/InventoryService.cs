using System.Text;

namespace InventoryManagementSystem
{
    public class InventoryService
    {
        private IProduct _repository;

        public InventoryService(IProduct repository)
        {
            _repository = repository;
        }

        public async Task AddProductAsync(Product newProduct)
        {
            await _repository.AddProductAsync(newProduct);
        }

        public async Task<bool> IsEmptyAsync()
        {
            return (await _repository.GetAllProductsAsync()).Count == 0;
        }

        public async Task<string> PrintAllProductsAsync()
        {
            if (await IsEmptyAsync())
                return "There are no products.";

            var allProducts = new StringBuilder();
            var products = await _repository.GetAllProductsAsync();

            for (var i = 0; i < products.Count; i++)
            {
                allProducts.Append($"""
                Product #{i + 1}:
                {products[i].ToString()}
                

                """);
            }

            return allProducts.ToString();
        }


        public async Task EditProductPriceAsync(Product product, decimal newPrice)
        {
            await _repository.EditProductPriceAsync(product.Name, newPrice);
        }

        public async Task EditProductNameAsync(string productName, string? newName)
        {
            await _repository.EditProductNameAsync(productName, newName);
        }

        
             public async Task EditProductQuantityAsync(string productName, int newQuantity)
        {
            await _repository.EditProductQuantityAsync(productName, newQuantity);
        }

        public async Task DeleteProductAsync(Product product)
        {
            await _repository.DeleteProductAsync(product.Name);
        }

        public async Task<Product?> FindProductAsync(string? productName)
        {
            return (await _repository.GetAllProductsAsync())
                .SingleOrDefault(product => product.Name == productName);
        }
    }
}