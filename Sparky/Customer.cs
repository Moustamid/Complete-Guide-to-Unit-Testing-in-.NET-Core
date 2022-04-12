namespace Sparky;

public class Customer
{
    
    public string GreetMessage { get; set; }
    public int discount { get; set; } = 15;
    
    public string GreetAndCombineNames(string firsName , string lastName)
    {
        if (string.IsNullOrWhiteSpace(firsName))
        {
            throw new ArgumentException("Empty firsName");
        }

        discount = 20;
        return GreetMessage =  $"Hello , {firsName} {lastName}";
    }
}