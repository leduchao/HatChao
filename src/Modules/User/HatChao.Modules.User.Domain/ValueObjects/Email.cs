using HatChao.SharedKernel.Domain.Abstractions;
using HatChao.SharedKernel.Utils;

namespace HatChao.Modules.User.Domain.ValueObjects;

public class Email : ValueObject
{
    public string EmailValue { get; set; }

    private Email(string email)
    {
        if (!IsValidEmail(email))
        {
            throw new ArgumentException("Email is not valid", nameof(email));
        }

        EmailValue = email;
    }

    public static Email Create(string value) => new(value);

    private static bool IsValidEmail(string email) => RegexPatterns.EmailRegex().IsMatch(email);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return EmailValue.ToLower();
    }
}
