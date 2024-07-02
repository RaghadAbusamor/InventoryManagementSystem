using MongoDB.Driver;

namespace InventoryManagementSystem
{
    public class DBRepository : IProductRepository
    {
        private MongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<Product> _productsCollection;

        public DBRepository()
        {
            _client = new MongoClient(MongoDBConnection.MongoDbConnectionString);
            _database = _client.GetDatabase(MongoDBConnection.databaseName);
            _productsCollection = _database.GetCollection<Product>(MongoDBConnection.collectionName);
        }

        public async Task AddProductAsync(Product newProduct)
        {
            await _productsCollection.InsertOneAsync(newProduct);
        }

        public async Task EditProductNameAsync(string oldName, string newName)
        {
            var nameUpdate = Builders<Product>.Update.Set("Name", newName);
            await _productsCollection.FindOneAndUpdateAsync(product => product.Name == oldName, nameUpdate);
        }

        public async Task EditProductPriceAsync(string productName, decimal newPrice)
        {
            var priceUpdate = Builders<Product>.Update.Set("Price", newPrice);
            await _productsCollection.FindOneAndUpdateAsync(product => product.Name == productName, priceUpdate);
        }

        public async Task EditProductQuantityAsync(string productName, int newQuantity)
        {
            var quantityUpdate = Builders<Product>.Update.Set("Quantity", newQuantity);
            await _productsCollection.FindOneAndUpdateAsync(product => product.Name == productName, quantityUpdate);
        }

        public async Task DeleteProductAsync(string productName)
        {
            await _productsCollection.DeleteOneAsync(product => product.Name == productName);
        }

        public async Task<List<Product>> GetAllProductsAsync() => (await _productsCollection.FindAsync(_ => true)).ToList();
    }
}