using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem_SQL.Model
{
  
        public static class ProductQueries
        {
            public static string GetAllProducts()
            {
                return "SELECT * FROM Products";
            }

            public static string IsEmpty()
            {
                return "SELECT TOP 1 * FROM Products";
            }
        }
    }


