namespace OnlineStoreProjectOOP;

public class Card
{
    private int Number;
    private double Sum;

    public Card(int number, int sum)
    {
        Number = number;
        Sum = sum;
    }

    public double GetSum()
    {
        return Sum;
    }

    public void SetSum(double Sum)
    {
        this.Sum = Sum;
    }

    public int GetNumber()
    {
        return Number;
    }
}