using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace SeminarApplication.Domain.Common;

public class CourseName : ValueOf<string, CourseName>
{
    private static readonly Regex Regex =
        new("^[a-z ,.'-]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    protected override void Validate()
    {
        if (!Regex.IsMatch(Value))
        {
            var message = $"{Value} is not a valid course name";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(CourseName), message)
            });
        }
    }
}