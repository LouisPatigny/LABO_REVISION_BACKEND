using System.Security.Cryptography;
using System.Text;

namespace exo_revisions.BLL.Interfaces;

public interface IPasswordHelper
{
    string GenerateHash(string email, string password);
}