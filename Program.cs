using System;
using System.Threading.Tasks;
using InventoryManagementSystem;

namespace InventoryManagementSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var productRepository = new DBOperations(); 
            var inventoryService = new InventoryService(productRepository);
            var inventoryManager = new InventoryManager(inventoryService);
            await inventoryManager.RunAsync();
        }
    }
}
