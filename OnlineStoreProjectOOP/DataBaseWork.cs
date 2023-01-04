namespace OnlineStoreProjectOOP;

public class DataBaseWork : DataBase
{
    public override void Show(Category product)
    {
        if (ProductsList != null)
            foreach (var element in ProductsList)
            {
                if (element.Type == product)
                {
                    Console.Write("ID: " + element.ID);
                    Console.Write("\tPrice: " + element.Price);
                    Console.WriteLine("\t\tName: " + element.Name);
                }
            }
    }

    public override Product SetProduct(int id)
    {
        if (ProductsList != null)
            foreach (var element in ProductsList)
            {
                if (id == element.ID)
                {
                    return element;
                }
            }

        return null!;
    }

    public override void RemoveProductWithProductsList(Product product)
    {
        ProductsList?.Remove(product);
    }
}