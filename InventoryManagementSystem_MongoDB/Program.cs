namespace InventoryManagementSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var productRepository = new DBRepository();
            var inventoryService = new InventoryService(productRepository);
            var inventoryManager = new InventoryManager(inventoryService);
            await inventoryManager.RunAsync();
        }
    }
}
