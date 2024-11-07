
using HW_11.Dapper;
using HW_11.Entities;
using HW_11.Services;

class Program
{
    static void Main(string[] args)
    {
        
        var dap = new DapperServices();

        
        while (true)
        {
            ShowMenu();
            int choice = GetChoiceFromUser();

            switch (choice)
            {
                case 1:
                    dap.AddProduct(); 
                    break;
                case 2:
                    dap.ShowAllProducts(); 
                    break;
                case 3:
                    dap.ShowProductById(); 
                    break;
                case 4:
                    dap.UpdateProduct(); 
                    break;
                case 5:
                    dap.DeleteProduct(); 
                    break;
                case 6:
                    Console.WriteLine("Logout");
                    return; 
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

