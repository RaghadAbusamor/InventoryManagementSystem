namespace InventoryManagementSystem
{
    public static class MongoDBConnection
    {
        public static string MongoDbConnectionString => "mongodb://0.0.0.0:27017/";
        public static string collectionName => "Product";
        public static string databaseName => "Inventory";
    }
}
