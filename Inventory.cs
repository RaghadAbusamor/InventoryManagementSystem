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

    }
}
