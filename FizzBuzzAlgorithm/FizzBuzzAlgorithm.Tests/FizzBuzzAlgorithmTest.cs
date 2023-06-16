namespace FizzBuzzAlgorithm.Tests;

[TestClass]
public class FizzBuzzAlgorithmTest
{
    [TestMethod]
    [DataRow(3, "fizz")]
    [DataRow(5, "buzz")]
    [DataRow(15, "fizzbuzz")]
    [DataRow(45, "fizzbuzz")]
    [DataRow(11, "11")]
    [DataRow(19, "19")]
    public void Process_Number_With_Delivered_Numbers_Returns_Proper_Keyword_Or_Value_As_String(int number, string expectedResult)
    {
        var algorithm = new Core.FizzBuzzAlgorithm();

        var result = algorithm.ProcessNumber(number);

        Assert.AreEqual(expectedResult, result);
    }
}