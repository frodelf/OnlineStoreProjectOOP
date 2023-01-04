namespace OnlineStoreProjectOOP;

public class Product
{
    public int ID;
    public Category Type;
    public string? Name;
    public double Price;

    public Product(int id, Category type, string? name, double price)
    {
        ID = id;
        Type = type;
        Name = name;
        Price = price;
    }
}