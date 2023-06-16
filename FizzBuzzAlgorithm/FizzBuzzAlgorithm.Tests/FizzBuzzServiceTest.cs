using FizzBuzzAlgorithm.Core;

namespace FizzBuzzAlgorithm.Tests;

[TestClass]
public class FizzBuzzServiceTest
{
    [TestMethod]
    [DataRow(3, "fizz")]
    [DataRow(5, "buzz")]
    [DataRow(15, "fizzbuzz")]
    [DataRow(45, "fizzbuzz")]
    [DataRow(11, "11")]
    [DataRow(19, "19")]
    public void ProcessNumber_Method_With_Delivered_Numbers_Should_Return_Proper_Keyword_Or_Value_As_String(int number, string expectedResult)
    {
        var algorithm = new FizzBuzzService();

        string result = algorithm.ProcessNumber(number);

        Assert.AreEqual(expectedResult, result);
    }
}