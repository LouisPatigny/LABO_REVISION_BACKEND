using System.Security.Cryptography;
using System.Text;
using exo_revisions.BLL.Interfaces;

namespace exo_revisions.BLL.Helpers;

public class PasswordHelper : IPasswordHelper
{
    public string GenerateHash(string email, string password)
    {
        string normalizeEmail = email.ToLower();
        string raw = $"{normalizeEmail}:{password}";

        using SHA256 sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(raw));

        StringBuilder sb = new StringBuilder();
        foreach (byte b in bytes)
        {
            sb.Append(b.ToString("x2"));
        }
        return sb.ToString();
    }
}