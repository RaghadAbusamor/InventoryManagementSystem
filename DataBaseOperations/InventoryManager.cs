
namespace InventoryManagementSystem
{
    public class InventoryManager
    {
        private readonly InventoryService _inventory;

        public InventoryManager(InventoryService inventory)
        {
            _inventory = inventory;
        }

        public async Task RunAsync()
        {
            while (true)
            {
                PrintMainMenu();
                bool isInputValid = Enum.TryParse(Console.ReadLine(), out Operations menuOption);
                if (!isInputValid || !Enum.IsDefined(typeof(Operations), menuOption))
                {
                    Console.WriteLine("Invalid option.");
                    continue;
                }

                switch (menuOption)
                {

                    case Operations.Add:
                        await AddProductAsync();
                        break;

                    case Operations.View:
                        await ViewAllProductsAsync();
                        break;

                    case Operations.Edit:
                        await EditProductAsync();
                        break;

                    case Operations.Delete:
                        await DeleteProductAsync();
                        break;

                    case Operations.Search:
                        await SearchProductAsync();
                        break;

                    case Operations.Exit:
                        return;

                    default:
                        Console.WriteLine("Please enter a valid option.");
                        break;
                }

                Console.Write("\nPress any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private async Task AddProductAsync()
        {
            Console.Write("Name of the product: ");
            var productName = Console.ReadLine();

            Console.Write("Price of the product: ");
            bool isInputValid = decimal.TryParse(Console.ReadLine(), out decimal productPrice);
            if (!isInputValid)
            {
                Console.WriteLine("Invalid price.");
                return;
            }

            Console.Write("Quantity of the product: ");
            isInputValid = int.TryParse(Console.ReadLine(), out int productQuantity);
            if (!isInputValid)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            var newProduct = new Product(productName, productPrice, productQuantity);

            if (newProduct.IsValid())
                await _inventory.AddProductAsync(newProduct);
            else
                Console.WriteLine("The values can't be negative.");
        }

        private async Task ViewAllProductsAsync()
        {
            Console.WriteLine(await _inventory.PrintAllProductsAsync());
        }

        private async Task EditProductAsync()
        {
            Console.Write("Name of a product to edit it: ");
            string productName = Console.ReadLine();

            var product = await _inventory.FindProductAsync(productName);
            if (product == null)
            {
                Console.WriteLine("The product is not found.");
                return;
            }

            await EditProductMenuAsync(product);
        }

        private async Task DeleteProductAsync()
        {
            Console.Write("Name of a product to delete it: ");
            string productName = Console.ReadLine();

            var product = await _inventory.FindProductAsync(productName);
            if (product == null)
            {
                Console.WriteLine("The product is not found.");
                return;
            }

            await _inventory.DeleteProductAsync(product);
        }

        private async Task SearchProductAsync()
        {
            Console.Write("Name of a product to search for it: ");
            string productName = Console.ReadLine();

            var product = await _inventory.FindProductAsync(productName);
            if (product == null)
            {
                Console.WriteLine("The product is not found.");
                return;
            }

            Console.WriteLine(product.ToString());
        }

        private async Task EditProductMenuAsync(Product product)
        {
            Console.Clear();
            Console.WriteLine($"The current data of {product.Name}: ");
            Console.WriteLine(product.ToString());

            PrintEditMenu();
            bool isInputValid = Enum.TryParse(Console.ReadLine(), out EditOptions menuOption);
            if (!isInputValid || !Enum.IsDefined(typeof(EditOptions), menuOption))
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            switch (menuOption)
            {
                case EditOptions.EditName:
                    Console.Write("Enter the new name: ");
                    var newName = Console.ReadLine();
                    await _inventory.EditProductNameAsync(product, newName);
                    break;

                case EditOptions.EditPrice:
                    Console.Write("Enter the new price: ");
                    isInputValid = decimal.TryParse(Console.ReadLine(), out decimal newPrice);
                    if (!isInputValid || !ProductValidation.IsValidPrice(newPrice))
                    {
                        Console.WriteLine("Invalid price.");
                        return;
                    }
                    await _inventory.EditProductPriceAsync(product, newPrice);
                    break;

                case EditOptions.EditQuantity:
                    Console.Write("Enter the new quantity: ");
                    isInputValid = int.TryParse(Console.ReadLine(), out int newQuantity);
                    if (!isInputValid || !ProductValidation.IsValidQuantity(newQuantity))
                    {
                        Console.WriteLine("Invalid quantity.");
                        return;
                    }
                    await _inventory.EditProductQuantityAsync(product, newQuantity);
                    break;

                case EditOptions.Cancel:
                    return;

                default:
                    Console.WriteLine("Please enter a valid edit option.");
                    break;
            }
        }

        private static void PrintEditMenu()
        {
            Console.WriteLine("\n1. Edit the name.");
            Console.WriteLine("2. Edit the price.");
            Console.WriteLine("3. Edit the quantity.");
            Console.WriteLine("4. Cancel.\n");
            Console.Write("Enter a valid option: ");
        }
        private static void PrintMainMenu()
        {
            Console.WriteLine("Inventory Management System\n");
            Console.WriteLine("1. Add a product.");
            Console.WriteLine("2. View all products.");
            Console.WriteLine("3. Edit a product.");
            Console.WriteLine("4. Delete a product.");
            Console.WriteLine("5. Search for a product.");
            Console.WriteLine("0. Exit.\n");
            Console.Write("Enter a valid option: ");
        }
    }
}
