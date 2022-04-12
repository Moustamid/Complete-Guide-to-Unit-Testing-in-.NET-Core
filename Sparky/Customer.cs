namespace Sparky;


public class Customer
{
    public int OrderTotal { get; set; }
    public string GreetMessage { get; set; }
    public int discount { get; set; } = 15;
    
    public bool IsPlatinum { get; set; }

    public Customer()
    {
        IsPlatinum = false;
    }
    public string GreetAndCombineNames(string firsName , string lastName)
    {
        if (string.IsNullOrWhiteSpace(firsName))
        {
            throw new ArgumentException("Empty firsName");
        }

        discount = 20;
        return GreetMessage =  $"Hello , {firsName} {lastName}";
    }
    
    public CustomerType GetCustomerDetails()
    {
        if (OrderTotal < 100)
        {
            return new BasicCustomer();
        }
        return new PlatinumCustomer();
    }
    
    public class CustomerType { }
    public class BasicCustomer :CustomerType { }
    public class PlatinumCustomer : CustomerType { }
}