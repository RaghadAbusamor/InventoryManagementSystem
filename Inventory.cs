﻿using System;
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
        private List<Product> Products  = new List<Product>();

        public void AddProduct()
        {
            Console.Write("Enter the name of the product: ");
            string? name = Console.ReadLine();

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
        public void ViewAllProducts()
        {
            int listSize = Products.Count;
            Console.WriteLine($"\n We have {listSize} products in our inventory\n");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("|       Name       |       Price       |       Quantity       |");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (Product product in Products )
            {
                Console.WriteLine($"| {product.Name,-15} | {product.Price,-17} | {product.QuantityInStock,-20} |");
            }
            Console.WriteLine("--------------------------------------------------------------------");
        }

        public void EditProduct()
        {
            Console.Write("Enter the name of the product to edit: ");
            string? name = Console.ReadLine();

            foreach (Product product in Products)
            {
                if (product.Name.Equals(name))
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
            Console.WriteLine($"{name} product not found :( ");
        }


        public void DeleteProduct()
        {
            Console.Write("Enter the name of the product to delete: ");
            string? name = Console.ReadLine();

            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Name.Equals(name))
                {
                    Products.RemoveAt(i);
                    Console.WriteLine("Product deleted!");
                    return;

                }
            } Console.WriteLine($"{name} product not found :( ");
        }

        public void SearchForProduct()
        {
            Console.Write("Enter the name of the product to edit: ");
            string? name = Console.ReadLine();
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Name.Equals(name))
                {
                    Console.WriteLine($"Name: {Products[i].Name}, Price: {Products[i].Price}, Quantity: {Products[i].QuantityInStock}");
                    return;

                }
            }
            Console.WriteLine($"{name} product not found :(");
        }

        public void Exit()
        {
            Console.WriteLine("Exiting, BYEEEEEE");
            Environment.Exit(0);
        }
    }
}
