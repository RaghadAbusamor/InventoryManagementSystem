using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InventoryManagementSystem
{
    public class ProductsException : Exception
    {
        public ProductsException(string message) : base(message)
        {
        }
    }
    public class Inventory
    {
        private List<Product> Products  = new List<Product>();
        public void AddProduct()
        {
            try {
                Console.Write("Enter the name of the product: ");
                string name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ProductsException("Product name cannot be empty");
                }

                Console.Write("Enter the price of the product: ");
                double price;
                while (!double.TryParse(Console.ReadLine(), out price))
                {
                    Console.WriteLine("Invalid input! Please enter a valid price.");
                }

                Console.Write("Enter the quantity of the product: ");
                int quantity;
                while (!int.TryParse(Console.ReadLine(), out quantity))
                {
                    Console.WriteLine("Invalid input! Please enter a valid quantity.");
                }

                Products.Add(new Product(name, price, quantity));
                Console.WriteLine($"Whooooh! A new Product added with name: {name}, price: {price}, and quantity: {quantity}");
            }
            catch (ProductsException e)
            {
                Console.WriteLine(e.Message);
            }
            }
        public void ViewAllProducts()
        {
            try
            {
                int Size = Products.Count;
                if (Size > 0)
                {
                    Console.WriteLine($"\n We have {Size} products in our inventory\n");
                    Console.WriteLine("--------------------------------------------------------------------");
                    Console.WriteLine("|       Name       |       Price       |       Quantity       |");
                    Console.WriteLine("--------------------------------------------------------------------");
                    foreach (Product product in Products)
                    {
                        Console.WriteLine($"| {product.Name,-15} | {product.Price,-17} | {product.QuantityInStock,-20} |");
                    }
                    Console.WriteLine("--------------------------------------------------------------------");
                }
                throw new ProductsException("There is no product to view.");
            }
            catch (ProductsException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void EditProduct()
        {
            try {
                Console.Write("Enter the name of the product to edit: ");
                string? name = Console.ReadLine();

                foreach (Product product in Products)
                {
                    if (product.Name.Equals(name, StringComparison.Ordinal))
                    {
                        Console.WriteLine("Enter the new name of the product:");
                        product.Name = Console.ReadLine();

                        Console.WriteLine("Enter the new price of the product:");
                        double price;
                        while (!double.TryParse(Console.ReadLine(), out price))
                        {
                            Console.WriteLine("Invalid input, Please enter a valid price:");
                        }
                        product.Price = price;

                        Console.WriteLine("Enter the new quantity of the product:");
                        int quantity;
                        while (!int.TryParse(Console.ReadLine(), out quantity))
                        {
                            Console.WriteLine("Invalid input, Please enter a valid quantity:");
                        }
                        product.QuantityInStock = quantity;

                        Console.WriteLine("Product Edited successfully!");
                        return;
                    }
                }
                throw new ProductsException($"{name} product not found :(");
            }
            catch(ProductsException ex)
            {
                Console.WriteLine(ex.Message);  
            }
        }    

        public void DeleteProduct()
        {
            try
            {
                Console.Write("Enter the name of the product to delete: ");
                string? name = Console.ReadLine();

                for (int i = 0; i < Products.Count; i++)
                {
                    if (Products[i].Name.Equals(name, StringComparison.Ordinal))
                    {
                        Products.RemoveAt(i);
                        Console.WriteLine("Product deleted!");
                        return;
                    }
                }
                throw new ProductsException($"{name} product not found :( ");
            }
            catch(ProductsException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SearchForProduct()
        {
            try {
                Console.Write("Enter the name of the product to edit: ");
                string? name = Console.ReadLine();
                for (int i = 0; i < Products.Count; i++)
                {
                    if (Products[i].Name.Equals(name, StringComparison.Ordinal))
                    {
                        Console.WriteLine($"Name: {Products[i].Name}, Price: {Products[i].Price}, Quantity: {Products[i].QuantityInStock}");
                        return;

                    }
                }
                throw new ProductsException($"{name} product not found :(");
            }
            catch (ProductsException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Exit()
        {
            Console.WriteLine("Exiting, BYEEEEEE");
            Environment.Exit(0);
        }
    }
}
