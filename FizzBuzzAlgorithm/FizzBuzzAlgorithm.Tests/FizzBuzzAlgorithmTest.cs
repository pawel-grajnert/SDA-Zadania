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
    public void Process_Number_With_Numbers_Devidabe_By_3_Delivered_Returns_Keyword_fizz(int number, string expectedResult)
    {
        var algorithm = new Core.FizzBuzzAlgorithm();

        var result = algorithm.ProcessNumber(number);

        Assert.AreEqual(expectedResult, result);
    }
}