using System;

namespace InventoryManagementSystem
{
    public enum Operation
    {
        Add = 1,
        View,
        Edit,
        Delete,
        Search,
        Exit
    }
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();

            Console.WriteLine("Welcome to the Inventory Management System!");

            while (true)
            {
                Console.WriteLine("\nChoose an operation:");
                Console.WriteLine("1. Add a product");
                Console.WriteLine("2. View all products");
                Console.WriteLine("3. Edit a product");
                Console.WriteLine("4. Delete a product");
                Console.WriteLine("5. Search for a product");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                if (!Enum.TryParse(Console.ReadLine(), out Operation choice) || !Enum.IsDefined(typeof(Operation), choice))
                {
                    Console.WriteLine("Invalid input! Please enter a valid operation");
                    continue;
                }
                switch (choice)
                {
                    case Operation.Add:
                        inventory.AddProduct();
                        break;
                    case Operation.View:
                        inventory.ViewAllProducts();
                        break;
                    case Operation.Edit:
                        inventory.EditProduct();
                        break;
                    case Operation.Delete:
                         inventory.DeleteProduct();
                        break;
                    case Operation.Search:
                        inventory.SearchForProduct();
                        break;
                    case Operation.Exit:
                        inventory.Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please choose a valid operation.");
                        break;
                }
            }
        }
    }
}
