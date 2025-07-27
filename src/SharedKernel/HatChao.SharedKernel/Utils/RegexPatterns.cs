using System.Text.RegularExpressions;

namespace HatChao.SharedKernel.Utils;

public partial class RegexPatterns
{
    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    public static partial Regex EmailRegex();

    [GeneratedRegex(@"^\+?[0-9]{9,15}$")]
    public static partial Regex NumberPhoneRegex();

    [GeneratedRegex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,}$")]
    public static partial Regex PasswordRegex();
}
