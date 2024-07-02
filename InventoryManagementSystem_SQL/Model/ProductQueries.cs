using System;

namespace InventoryManagementSystem_SQL.Model
{
    public static class ProductQueries
    {
        public const string GetAllProducts = "SELECT * FROM Products";

        public const string IsEmpty = "SELECT COUNT(*) FROM Products";
    }
}
