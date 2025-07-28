using HatChao.SharedKernel.Utils;
using System.Security.Cryptography;
using System.Text;

namespace HatChao.Modules.User.Infrastructure.Persistence;

public static class PasswordHelper
{
    private const string _salt = "*** a salt is used to hash password ***";

    public static string Hash(string plainPassword)
    {
        if (!RegexPatterns.PasswordRegex().IsMatch(plainPassword))
        {
            throw new ArgumentException(
                "Password must be at least 8 characters, include uppercase, lowercase, number, and special character", 
                nameof(plainPassword));
        }

        string saltedPassword = plainPassword + _salt;
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(saltedPassword));

        StringBuilder strBuilder = new();
        for (int i = 0; i < bytes.Length; i++)
        {
            strBuilder.Append(bytes[i].ToString("x2"));
        }

        return strBuilder.ToString();
    }
}
