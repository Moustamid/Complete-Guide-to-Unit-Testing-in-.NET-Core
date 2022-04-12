using System;
using NUnit.Framework;

namespace Sparky;

[TestFixture]
public class CustomerNUnitTests
{
    private Customer customer;
    [SetUp]
    public void Setup()
    {
        customer = new Customer();
    }
    
    [Test]
    public void GreetAndCombineNames_InputFirsNameAndLastName_ReturnFullName()
    {
        //- Arrange
        // var customer = new Customer();
        
        //- Act
        var fullName = customer.GreetAndCombineNames("Karim" , "Moustamid" );
        
        //-Assert
        Assert.Multiple(() =>
        {
            Assert.AreEqual(fullName ,"Hello , Karim Moustamid");
            Assert.That(customer.GreetMessage , Is.EqualTo("Hello , Karim Moustamid"));
            Assert.That(customer.GreetMessage , Does.Contain(",")); // Note : Contain is case sensitive 
            Assert.That(customer.GreetMessage , Does.Contain("moustamid").IgnoreCase); 
            Assert.That(customer.GreetMessage , Does.StartWith("Hello"));
            Assert.That(customer.GreetMessage , Does.EndWith("Moustamid"));
            Assert.That(customer.GreetMessage , Does.Match("Hello , [A-Z{1}][a-z]+ [A-Z{1}][a-z]+"));
        });

    }

    [Test]
    public void GreetMessage_NotGreeted_ReturnNull()
    {
        //- Arrange
        // var customer = new Customer();
        
        //-Assert
        Assert.IsNull(customer.GreetMessage);

    } 
    
    [Test]
    public void DiscountCheck_DefaultCustomer_ReturnDiscountInRange()
    {
        var result = customer.discount;
        Assert.That(result , Is.InRange(10,25));
    }
    
    
    [Test]
    public void GreetMessage_GreetedWithoutLastName()
    {
        customer.GreetAndCombineNames("Karim", "");
        
        Assert.IsNotNull(customer.GreetMessage);
        Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));

    }
    
    [Test]
    public void GreetMessage_EmptyFirstName_ThrowsException()
    {
        var exceptionDetails = Assert.Throws<ArgumentException>(() =>
            customer.GreetAndCombineNames("" , "Moustamid"));
        
        Assert.AreEqual("Empty firsName", exceptionDetails.Message);
        
        Assert.That(() => customer.GreetAndCombineNames("" , "Moustamid") 
            , Throws.ArgumentException.With.Message.EqualTo("Empty firsName"));
        
        
        //. Exception without message 
        Assert.Throws<ArgumentException>(() =>
            customer.GreetAndCombineNames("" , "Moustamid"));

        Assert.That(() => customer.GreetAndCombineNames("" , "Moustamid") 
            , Throws.ArgumentException);
    }
    
    


}