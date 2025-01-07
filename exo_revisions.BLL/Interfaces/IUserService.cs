using exo_revisions.BLL.Models;

namespace exo_revisions.BLL.Interfaces;

public interface IUserService
{
    public IEnumerable<User> GetAll();
    public User? GetById(int id);
    public User? GetByEmail(string email);
    public int Create(User user);
    public User? Login(string email);
    public int GetFidelityPoints(int id);
    public int UpdateFidelityPoints(int id, int points);
}