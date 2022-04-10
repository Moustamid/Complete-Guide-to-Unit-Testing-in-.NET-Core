namespace Sparky;

public class Customer
{
    
    public string GreetMessage { get; set; }
    public string GreetAndCombineNames(string firsName , string lastName)
    {  

        return GreetMessage =  $"Hello , {firsName} {lastName}";
    }

}