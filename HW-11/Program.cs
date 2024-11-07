
using HW_11.Dapper;
using HW_11.Entities;
using HW_11.Services;

class Program
{
    static void Main(string[] args)
    {
        // Initialize DapperServices instance
        var dap = new DapperServices();

        // Infinite loop for menu
        while (true)
        {
            ShowMenu();
            int choice = GetChoiceFromUser();

            switch (choice)
            {
                case 1:
                    dap.AddProduct(); // Call method to add product
                    break;
                case 2:
                    dap.ShowAllProducts(); // Call method to show all products
                    break;
                case 3:
                    dap.ShowProductById(); // Call method to show product by ID
                    break;
                case 4:
                    dap.UpdateProduct(); // Call method to update product
                    break;
                case 5:
                    dap.DeleteProduct(); // Call method to delete product
                    break;
                case 6:
                    Console.WriteLine("Logout");
                    return; // Exit the program
                default:
                    Console.WriteLine("Wrong option, please choose again.");
                    break;
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. Add a new product");
        Console.WriteLine("2. Show list of products");
        Console.WriteLine("3. Show product by ID");
        Console.WriteLine("4. Update product");
        Console.WriteLine("5. Delete product");
        Console.WriteLine("6. Exit");
    }

    static int GetChoiceFromUser()
    {
        int choice;
        Console.Write("Enter your choice: ");
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
        {
            Console.Write("Please enter a valid option (1 to 6): ");
        }
        return choice;
    }
}

