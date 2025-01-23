// See https://aka.ms/new-console-template for more information

using System.Linq.Expressions;
using Mission003Assignment3;

internal class Program
{
    public static void Main(string[] args)
    {
        bool exit = false;
        List<FoodItem> foodItems = new List<FoodItem>(); // List to store food items
        
        // starts the program
        Console.WriteLine("Welcome to the Food Bank Inventory System.");
        while (!exit)
        {
            
            
            string MenuItemInput = "";

            Console.WriteLine(
                "Enter the corresponding number in the menu to proceed.");
            Console.WriteLine(
                "\n        Menu\n  1: Add Food Items\n  2: Delete Food Items\n  3: Print List of Current Food Items\n  4: Exit the Program");
            MenuItemInput = Console.ReadLine();
            
            // option if they choose to add a food item
            if (MenuItemInput == "1")
            {


                Console.WriteLine("Enter the name of the food item: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the category: ");
                string category = Console.ReadLine();
                // error handeling for int
                Console.WriteLine("Enter the quantity: ");
                int quantity;
                // checks for quanity
                while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer for the quantity: ");
                }
                // error handleing for the date time
                DateTime expirationDate;
                Console.WriteLine("Enter the expiration date (yyyy-MM-dd): ");
                while (!DateTime.TryParse(Console.ReadLine(), out expirationDate))
                {
                    Console.WriteLine("Invalid date format. Please enter a valid date in the format yyyy-MM-dd: ");
                }
                Console.WriteLine($"Expiration date set to: {expirationDate.ToShortDateString()}");

                
                FoodItem fi = new FoodItem(name, category, quantity, expirationDate);
                foodItems.Add(fi);

            }

            else if(MenuItemInput == "2")
            {
                // Delete food item
                bool itemDeleted = false;

                while (!itemDeleted)
                {
                    Console.WriteLine("Enter the name of the food item to delete: ");
                    string nameToDelete = Console.ReadLine();
                    FoodItem itemToRemove = foodItems.Find(f => f.FoodName.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

                    if (itemToRemove != null)
                    {
                        foodItems.Remove(itemToRemove);
                        Console.WriteLine("Food item removed successfully.\n");
                        itemDeleted = true; // Exit the loop
                    }
                    else
                    {
                        Console.WriteLine("Food item not found. Please try again.\n");
                    }
                }
            }
            else if(MenuItemInput == "3")
            {
                // lists the menu out of it
                if (foodItems.Count == 0)
                {
                    Console.WriteLine("No food items in inventory.\n");
                }
                else
                {
                    Console.WriteLine("\nCurrent Food Items:");
                    foreach (FoodItem fi in foodItems) // Use 'fi' here to refer to each item in the list
                    {
                        Console.WriteLine(fi.Display()); // Display details of each food item
                    }
                    Console.WriteLine();
                }
            }
            
            // exits the program
            else if(MenuItemInput == "4")
            { 
                exit = true;
            }
            else
            {
                Console.WriteLine("\nPlease enter a valid number: ");
            }

    }

    }
}