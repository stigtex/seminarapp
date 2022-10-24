using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace SeminarApplication.Domain.Common;

public class LastName : ValueOf<string, LastName>
{
    private static readonly Regex Regex =
        new("^[a-z ,.'-]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    protected override void Validate()
    {
        if (!Regex.IsMatch(Value))
        {
            var message = $"{Value} is not a valid last name";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(LastName), message)
            });
        }
    }
}