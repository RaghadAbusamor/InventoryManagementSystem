using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int QuantityInStock { get; set; }

        public Product(string name, double price, int quantityInStock)
        {
            Name = name;
            Price = price;
            QuantityInStock = quantityInStock;
        }
    }
}