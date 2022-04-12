using System.Collections.Generic;
using NUnit.Framework;

namespace Sparky;

[TestFixture]
public class CalculatorNUnitTests
{
    private Calculator calculator;
    
    [SetUp]
    public void SetUp()
    {
        calculator = new Calculator();
    }

    [Test]
    public void AddNumbers_InputTwoInt_GetCorrectAddition()
    {   
        //- Arrange

      
        //- Act
        var result = calculator.AddNumbers(10,20);
      
        //- Assert
        Assert.AreEqual(30 , result);
    }

    [Test]
    public void IsOddNumber_InputEvenNumber_ReturnFalse()
    {
        //- Arrange

        
        //- Act
        var isOdd = calculator.IsOddNumber(10);

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

        
        //- Act
        var result = calculator.IsOddNumber(a);
        
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
    
    
    [Test]
    [TestCase(5.4 , 10.5)]     //15.9
    [TestCase(5.43 , 10.53)]  //15.96
    [TestCase(5.49 , 10.59)] //16.08
    public void AddNumbersDoubles_InputTwoDoubles_GetCorrectAddition(double a , double b)
    {
        //- Arrange

        //- Act
        var result = calculator.AddNumbersDouble(a,b);
        
        //- Assert
        Assert.AreEqual(15.9 , result , 1); // Between {14.9 - 16.9}
    }

    [Test]
    public void GetOddRange_InputMinAndMaxRange_ReturnValidOddNumberRangeList()
    {
        //- Arrange
        List<int> expectedOddRange = new() { 5 ,7 ,9 };
        
        //- Act
        var result = calculator.GetOddRnage(5, 10);
        
        //- Assert
        Assert.That(result , Is.EquivalentTo(expectedOddRange));
        Assert.AreEqual(expectedOddRange , result);
        Assert.Contains(7,result);
        Assert.That(result , Does.Contain(7));
        Assert.That(result , Is.Not.Empty);
        Assert.That(result.Count , Is.EqualTo(3));
        Assert.That(result , Has.No.Member(6));
        Assert.That(result , Is.Ordered);
        // Assert.That(result , Is.Ordered.Descending);
        Assert.That(result , Is.Unique);
    }


}