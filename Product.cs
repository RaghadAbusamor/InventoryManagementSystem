using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    public class Product
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int QuantityInStock { get; private set; }

        public Product(string name, double price, int quantityInStock)
        {
            Name = name;
            Price = price;
            QuantityInStock = quantityInStock;
        }
    }

    public class Inventory
    {
            private List<Product> listOfProducts = new List<Product>();
    }



}