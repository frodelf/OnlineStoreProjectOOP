using Newtonsoft.Json;

namespace OnlineStoreProjectOOP;

public class Product
{
    public int ID;
    protected static int getID = 1000;
    public Kategory Type;
    public string? Name;
    public double Price;

    public Product(int id, Kategory type, string? name, double price)
    {
        ID = id;
        Type = type;
        Name = name;
        Price = price;
    }

    public enum Kategory
    {
        Clothes,
        Gadget,
        Food,
        Sport,
        Another,
    }
}