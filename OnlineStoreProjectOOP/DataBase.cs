using System.Security.Cryptography;
using System.Text;

namespace OnlineStoreProjectOOP;

public abstract class DataBase
{
    public List<Product>? ProductsList { get; set; }
    public List<User> UserLists;

    public DataBase()
    {
        ProductsList = new List<Product>();
        UserLists = new List<User>
        {
            new User("1", GetHash("1"), new Card(1001, 10000), false),
            new User("Ivan", GetHash("2345"), new Card(1002, 13000), true),
            new User("Artem", GetHash("1234"), new Card(1003, 8000), false),
        };
    }

    public abstract void Show(Category product);
    public abstract Product SetProduct(int id);
    public abstract void RemoveProductWithProductsList(Product product);
    
    public static string GetHash(string? password)
    {
        using (var hash = SHA1.Create())
        {
            return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password))
                .Select(x => x.ToString("X2")));
        }
    }
}