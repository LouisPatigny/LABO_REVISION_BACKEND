namespace exo_revisions.BLL.Interfaces;

public interface IJwtService
{
    string GenerateJwtToken(int id, string email);
}