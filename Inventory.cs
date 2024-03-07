using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InventoryManagementSystem
{
    public class Inventory
    {
        private List<Product> listOfProducts = new List<Product>();

        public void AddProduct(string name, double price, int quantity)
        {
            listOfProducts.Add(new Product(name, price, quantity));
            Console.WriteLine($"Whooooh! A new Product added with name: {name}, price: {price}, and quantity: {quantity}");

        }
        public void ViewAllProducts()
        {
            int listSize = listOfProducts.Count;
            Console.WriteLine($"\n We have {listSize} products in our inventory\n");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("|       Name       |       Price       |       Quantity       |");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (Product product in listOfProducts)
            {
                Console.WriteLine($"| {product.Name,-15} | {product.Price,-17} | {product.QuantityInStock,-20} |");
            }
            Console.WriteLine("--------------------------------------------------------------------");
        }

        public void EditProduct(string name)
        {
            foreach (Product product in listOfProducts)
            {
                if (product.Name == name)
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
            Console.WriteLine($"{name} product not found!");
        }

        public void DeleteProduct(string name)
        {
            for (int i = 0; i < listOfProducts.Count; i++)
            {
                if (listOfProducts[i].Name == name)
                {
                    listOfProducts.RemoveAt(i);
                    Console.WriteLine("Product deleted!");
                    return;

                }
            } Console.WriteLine($"{name} product not found!");
        }

    }
}
