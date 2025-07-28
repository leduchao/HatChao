using HatChao.SharedKernel.Domain.Abstractions;
using HatChao.SharedKernel.Utils;
using System.Security.Cryptography;
using System.Text;

namespace HatChao.Modules.User.Domain.ValueObjects;

public class PasswordHash : ValueObject
{
    public string HashedValue { get; private set; } = null!;

    private PasswordHash(string hashedValue)
    {
        HashedValue = hashedValue;
    }

    public static PasswordHash Create(string plainPassword, string salt)
    {
        if (!RegexPatterns.PasswordRegex().IsMatch(plainPassword))
        {
            throw new ArgumentException(
                "Password must be at least 8 characters, include uppercase, lowercase, number, and special character", 
                nameof(plainPassword));
        }

        string saltedPassword = plainPassword + salt;
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(saltedPassword));

        StringBuilder strBuilder = new();
        for (int i = 0; i < bytes.Length; i++)
        {
            strBuilder.Append(bytes[i].ToString("x2"));
        }

        return new PasswordHash(strBuilder.ToString());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return HashedValue;
    }
}
