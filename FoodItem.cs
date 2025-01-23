namespace Mission003Assignment3;

public class FoodItem
{
    // Properties
    public string FoodName { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpirationDate { get; set; }

    // Constructor
    public FoodItem(string foodName, string category, int quantity, DateTime expirationDate)
    {
        // sets basic fooditem variables
        FoodName = foodName;
        Category = category;
        Quantity = quantity;
        ExpirationDate = expirationDate;
    }
    
    public  string Display()
    {
        return $"\nFood Name: {FoodName}\n Category: {Category}\n Quantity: {Quantity}\n Expiration Date: {ExpirationDate.ToShortDateString()}";
    }
     
}