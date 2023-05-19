using static Converter.Repository.CharacterCodesRepository;

namespace Converter.InputValidation;

public class Validator
{
    public bool IsValid(string input)
    {
        return input.ToLower().Trim().All(Exist);
    }
}