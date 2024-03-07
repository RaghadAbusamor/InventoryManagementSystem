using System;

namespace InventoryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();

            inventory.AddProduct("Product 11", 10.99, 100);
            inventory.AddProduct("Product 22", 12.99, 120);
            inventory.ViewAllProducts();
            inventory.EditProduct("Product 11");

        }
    }
}
