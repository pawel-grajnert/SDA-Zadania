using System.Text;

namespace FizzBuzzAlgorithm.Core;

public class FizzBuzzService
{
    private const string Buzz = "buzz";
    private const string Fizz = "fizz";

    public string ProcessNumber(int number)
    {
        StringBuilder resultBuilder = new();

        if (number % 3 == 0)
        {
            resultBuilder.Append(Fizz);
        }
        
        if (number % 5 == 0)
        {
            resultBuilder.Append(Buzz);
        }

        if (resultBuilder.Length == 0)
        {
            resultBuilder.Append($"{number}");
        }

        return resultBuilder.ToString();
    }
}