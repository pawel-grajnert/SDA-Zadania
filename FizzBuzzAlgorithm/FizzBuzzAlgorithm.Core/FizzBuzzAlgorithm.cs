using System.Text;

namespace FizzBuzzAlgorithm.Core;

public class FizzBuzzAlgorithm
{
    public string ProcessNumber(int number)
    {
        StringBuilder resultBuilder = new();

        if (number % 3 == 0)
        {
            resultBuilder.Append("fizz");
        }
        
        if (number % 5 == 0)
        {
            resultBuilder.Append("buzz");
        }

        if (resultBuilder.Length == 0)
        {
            resultBuilder.Append($"{number}");
        }

        return resultBuilder.ToString();
    }
}