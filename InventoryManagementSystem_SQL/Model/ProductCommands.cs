using System;

namespace InventoryManagementSystem_SQL.Model
{
    public static class ProductCommands
    {
        public const string InsertProduct = @"
            INSERT INTO Products (Name, Price, Quantity)
            VALUES (@Name, @Price, @Quantity)";

        public const string UpdateProductName = @"
            UPDATE Products
            SET Name = @NewName
            WHERE Name = @OldName";

        public const string UpdateProductPrice = @"
            UPDATE Products
            SET Price = @NewPrice
            WHERE Name = @ProductName";

        public const string UpdateProductQuantity = @"
            UPDATE Products
            SET Quantity = @NewQuantity
            WHERE Name = @ProductName";

        public const string DeleteProduct = @"
            DELETE FROM Products
            WHERE Name = @ProductName";
    }
}
