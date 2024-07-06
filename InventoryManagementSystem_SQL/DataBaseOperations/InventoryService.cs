using System.Text;

namespace InventoryManagementSystem
{
    public class InventoryService
    {
        private IProductRepository _repository;

        public InventoryService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task AddProductAsync(Product newProduct)
        {
            await _repository.AddProductAsync(newProduct);
        }

        public async Task<bool> IsEmptyAsync()
        {
            return await _repository.IsEmptyAsync();
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

        public async Task EditProductNameAsync(string productName, string newName)
        {
            await _repository.EditProductNameAsync(productName, newName);
        }

        public async Task EditProductPriceAsync(string productName, decimal newPrice)
        {
            await _repository.EditProductPriceAsync(productName, newPrice);
        }

        public async Task EditProductQuantityAsync(string productName , int newQuantity)
        {
            await _repository.EditProductQuantityAsync(productName, newQuantity);
        }

        public async Task DeleteProductAsync(Product product)
        {
            await _repository.DeleteProductAsync(product.Name);
        }

        public async Task<Product?> FindProductAsync(string productName)
        {
            return (await _repository.GetAllProductsAsync())
                .SingleOrDefault(product => product.Name == productName);
        }
    }
}