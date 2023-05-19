using Converter.Converters;

namespace Converter.ConsoleControllers;

public class ConverterController
{
    public void RunProcess()
    {
        var converter = new CharacterConverter();
        bool runAgain;

        do
        {
            try
            {
                Console.Write("Type word to convert it into, a old phone key sequence.\n\nYour Word: ");
                string input = Console.ReadLine();
                string convertedInput = converter.Convert(input);
                Console.WriteLine($"Your old phone key sequence: {convertedInput}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Unexpected error occurs:\n\nError name:{nameof(exception)} {exception.Message}");
            }
            finally
            {
                Console.WriteLine("\n\nYou want to try convert another word? (y / n)");

                if (Console.ReadKey(true).Key == ConsoleKey.Y)
                {
                    runAgain = true;
                    Console.Clear();
                }
                else
                {
                    runAgain = false;
                }
            }
        } while (runAgain);
    }
}