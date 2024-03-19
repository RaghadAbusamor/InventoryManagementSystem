using System;

namespace InventoryManagementSystem
{
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
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number between 1 and 6.");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        inventory.AddProduct();
                        break;
                    case 2:
                        inventory.ViewAllProducts();
                        break;
                    case 3:
                        inventory.EditProduct();
                        break;
                    case 4:
                         inventory.DeleteProduct();
                        break;
                    case 5:
                        inventory.SearchForProduct();
                        break;
                    case 6:
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
