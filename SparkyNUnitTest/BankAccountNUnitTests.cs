using Moq;
using NUnit.Framework;

namespace Sparky;

[TestFixture]
public class BankAccountNUnitTests
{

    private BankAccount account;
    [SetUp]
    public void Setup()
    {
        
    }
    
    
    [Test]
    public void BankDeposit_Add100_ReturnTrue()
    {
        var logMock = new Mock<ILogBook>();
        
        var bankAccount = new BankAccount(logMock.Object);
        
        var result = bankAccount.Deposit(100);
        
        Assert.That(result, Is.True);
        Assert.That(bankAccount.balance, Is.EqualTo(100));
    }

}