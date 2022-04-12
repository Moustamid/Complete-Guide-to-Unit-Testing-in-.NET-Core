using NUnit.Framework;

namespace Sparky;

[TestFixture]
public class BankAccountNUnitTests
{

    private BankAccount bankAccount;
    [SetUp]
    public void Setup()
    {
        bankAccount = new BankAccount(new LogFakker());
    }

    [Test]
    public void BankDeposit_Add100_ReturnTrue()
    {
        var result =bankAccount.Deposit(100);
        Assert.That(result, Is.True);
        Assert.That(bankAccount.balance, Is.EqualTo(100));
    }

}