using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem_SQL.Model
{
  
        public static class ProductCommands
        {
            public static string InsertProduct()
            {
                return @"
                INSERT INTO Products (Name, Price, Quantity)
                VALUES (@Name, @Price, @Quantity)";
            }

            public static string UpdateProductName()
            {
                return @"
                UPDATE Products
                SET Name = @NewName
                WHERE Name = @OldName";
            }

            public static string UpdateProductPrice()
            {
                return @"
                UPDATE Products
                SET Price = @NewPrice
                WHERE Name = @ProductName";
            }

            public static string UpdateProductQuantity()
            {
                return @"
                UPDATE Products
                SET Quantity = @NewQuantity
                WHERE Name = @ProductName";
            }

            public static string DeleteProduct()
            {
                return @"
                DELETE FROM Products
                WHERE Name = @ProductName";
            }
        }
    }


