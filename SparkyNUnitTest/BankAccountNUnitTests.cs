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

    [Test]
    [TestCase(200,100)]
    [TestCase(200, 150)]
    public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
    {
        var logMock = new Mock<ILogBook>();
        logMock.Setup( u => u.LogToDb(It.IsAny<string>())).Returns(true);
        logMock.Setup( u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);
        
        var bankAccount = new BankAccount(logMock.Object);
        bankAccount.Deposit(balance);

        var result = bankAccount.Withrdraw(withdraw);
        Assert.IsTrue(result);

    }
    
    [Test]
    [TestCase(200, 300)]
    public void BankWithdraw_Withdraw300With200Balance_ReturnsFalse(int balance, int withdraw)
    {
        var logMock = new Mock<ILogBook>();

        // logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true); // the Default will be False if x => x > 0 is not true .
        // logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false); // return false 
        logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue,-1,Moq.Range.Inclusive))).Returns(false);
        BankAccount bankAccount = new(logMock.Object);
        bankAccount.Deposit(balance);
        var result = bankAccount.Withrdraw(withdraw);
        Assert.IsFalse(result);
    }
    
    
    [Test]
    public void BankLogDummy_LogMockString_ReturnTrue()
    {
        var logMock = new Mock<ILogBook>();
        string desiredOutput = "hello";

        logMock.Setup(u => u.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());

        Assert.That(logMock.Object.MessageWithReturnStr("HELLo"), Is.EqualTo(desiredOutput));
    }


}