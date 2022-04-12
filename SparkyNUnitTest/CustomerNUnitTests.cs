using NUnit.Framework;

namespace Sparky;

[TestFixture]
public class CustomerNUnitTests
{
    [Test]
    public void GreetAndCombineNames_InputFirsNameAndLastName_ReturnFullName()
    {
        //- Arrange
        var customer = new Customer();
        
        //- Act
        var fullName = customer.GreetAndCombineNames("Karim" , "Moustamid" );
        
        //-Assert
        Assert.AreEqual(fullName ,"Hello , Karim Moustamid");
        Assert.That(customer.GreetMessage , Is.EqualTo("Hello , Karim Moustamid"));
        Assert.That(customer.GreetMessage , Does.Contain(",")); // Note : Contain is case sensitive 
        Assert.That(customer.GreetMessage , Does.Contain("moustamid").IgnoreCase); 
        Assert.That(customer.GreetMessage , Does.StartWith("Hello"));
        Assert.That(customer.GreetMessage , Does.EndWith("Moustamid"));
        Assert.That(customer.GreetMessage , Does.Match("Hello , [A-Z{1}][a-z]+ [A-Z{1}][a-z]+"));
    }

    [Test]
    public void GreetMessage_NotGreeted_ReturnNull()
    {
        //- Arrange
        var customer = new Customer();
        
        //-Assert
        Assert.IsNull(customer.GreetMessage);

    }




}