using System.Threading.Tasks;

namespace InventoryManagementSystem
{
   public static class Program
    {
        public static async Task Main(string[] args)
        {
            var productRepository = new DBOperations();
            var inventoryService = new InventoryService(productRepository);
            var inventoryManager = new InventoryManager(inventoryService);
            await inventoryManager.RunAsync();
        }
    }
}
