using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    public class ProductsException : Exception
    {
        public ProductsException(string message) : base(message)
        {
        }
    }
}
