namespace OnlineStoreProjectOOP;

public class User
{
    protected static List<Product> _basket;
    protected string? _name;
    protected string _password;
    public Card Card;
    protected bool _vipStatus;

    public User(string? name, string password, Card card, bool vipStatus)
    {
        _basket = new List<Product>();
        _name = name;
        _password = password;
        Card = card;
        _vipStatus = vipStatus;
    }
    public void Buy()
    {
        double sum = 0;
        if (_basket != null)
        {
            foreach (var element in _basket)
            {
                Runner.dataBase.RemoveProductWithProductsList(Runner.dataBase.SetProduct(element.ID));
                sum += element.Price;
            }

            if (sum > Card.GetSum()) Console.WriteLine("Insufficient funds, top up the account");
            else
            {
                if (_vipStatus) Card.SetSum(Card.GetSum() - sum * 0.3);
                else Card.SetSum(Card.GetSum() - sum);
                _basket.Clear();
            }
        }
    }

    public static bool Reg()
    {
        Console.Write("Login: ");
        string? userName = Console.ReadLine();
        Console.Write("Password: ");
        string? password = Console.ReadLine();
        
        foreach (var user in Runner.dataBase.UserLists)
        {
            if (user._name.Equals(userName) && user._password.Equals(DataBase.GetHash(password)))
            {
                Runner.User = user;
                Console.WriteLine("You are logged in: " + userName);
                return true;
            }
        }
        return false;
    }

    public void AddBasket(int id)
    {
        _basket.Add(Runner.dataBase.SetProduct(id));
    }

    public void ShowBasket()
    {
        foreach (var element in _basket)
        {
            Console.Write("ID: " + element.ID);
            Console.Write("\tPrice: " + element.Price);
            Console.WriteLine("\t\tName: " + element.Name);
        }
    }

    public void DaniUser()
    {
        string status;
        if (_vipStatus) status = "Active";
        else status = "Passive";
        Console.WriteLine("Name: " + _name);
        Console.WriteLine("Vip status: " + status);
        Console.WriteLine("Money: " + Card.GetSum());
    }
}