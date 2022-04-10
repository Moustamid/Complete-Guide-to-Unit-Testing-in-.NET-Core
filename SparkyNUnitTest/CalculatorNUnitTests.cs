using NUnit.Framework;

namespace Sparky;

[TestFixture]
public class CalculatorNUnitTests
{
    [Test]
    public void AddNumbers_InputTwoInt_GetCorrectAddition()
    {   
        //- Arrange
        Calculator calc = new();
      
        //- Act
        var result = calc.AddNumbers(10,20);
      
        //- Assert
        Assert.AreEqual(30 , result);
    }

    [Test]
    public void IsOddNumber_InputEvenNumber_ReturnFalse()
    {
        //- Arrange
        Calculator calc = new();
        
        //- Act
        var isOdd = calc.IsOddNumber(10);

        //- Assert
        Assert.IsFalse(isOdd);
        Assert.That(isOdd , Is.EqualTo(false));
    }
    
    [Test]
    [TestCase(11)]
    [TestCase(13)]
    [TestCase(15)]
    public void IsOddNumber_InputOddNumber_ReturnTrue(int a)
    {
        //- Arrange
        var calc = new Calculator();
        
        //- Act
        var result = calc.IsOddNumber(a);
        
        //- Assert
        Assert.IsTrue(result);
        Assert.That(result , Is.EqualTo(true));
    }


    [Test]
    [TestCase(10, ExpectedResult = false)]
    [TestCase(11, ExpectedResult = true)]
    public bool IsOddNumber_InputNumber_ReturnTrueIfOdd(int a)
    {
        //- Arrange
        var calc = new Calculator();
        
        //- Act & Assert
        return calc.IsOddNumber(a);   
    }



}