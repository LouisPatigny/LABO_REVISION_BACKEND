using exo_revisions.DAL.Entities;

namespace exo_revisions.DAL.Interfaces;

public interface IUserRepository
{
    public User? Login(string email);
}