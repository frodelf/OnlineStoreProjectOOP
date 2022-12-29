using System.Security.Cryptography;
using System.Text;

namespace OnlineStoreProjectOOP;

public class DataBase{
    public List<Product>? ProductsList { get; set; }
    public List<User> UserLists { get; set; }

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

        
        public void Show(Product.Kategory product)
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
        public Product SetProduct(int id)
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

        public void RemoveProductWithProductsList(Product product)
        {
            ProductsList?.Remove(product);
        }
        public User AddUser(string? name, string? password, Card card, bool VIP)
        {
            return new User(name, GetHash(password), card, VIP);
        }
        
        public static string GetHash(string? password)
        {
            using (var hash = SHA1.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password))
                        .Select(x => x.ToString("X2")));
            }
        }
    }