using Converter.InputValidation;
using Converter.Repository;

namespace Converter.Converters;

public class CharacterConverter
{
    public string Convert(string value)
    {
        var inputValidator = new Validator();

        if (!inputValidator.IsValid(value.ToLower().Trim()))
        {
            return "Invalid input. Please use only english letters without any special characters.";
        }

        var characterCodes = value.ToLower().Trim().Select(c => CharacterCodesRepository.GetCharacterCode(c));
        var result = string.Join(string.Empty, characterCodes);

        return result;
    }
}