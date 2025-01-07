using exo_revisions.BLL.Interfaces;
using exo_revisions.BLL.Mappers;
using exo_revisions.BLL.Models;
using exo_revisions.DAL.Interfaces;

namespace exo_revisions.BLL.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IEnumerable<User> GetAll()
    {
        return _userRepository.GetAll().Select(u => u.ToModel());
    }

    public User? GetById(int id)
    {
        return _userRepository.GetById(id)?.ToModel();
    }

    public User? GetByEmail(string email)
    {
        return _userRepository.GetByEmail(email)?.ToModel();
    }

    public int Create(User user)
    {
        return _userRepository.Create(user.ToEntity());
    }

    public User? Login(string email)
    {
        return _userRepository.Login(email)?.ToModel();
    }

    public int GetFidelityPoints(int id)
    {
        return _userRepository.GetFidelityPoints(id);
    }

    public int UpdateFidelityPoints(int id, int points)
    {
        int currentPoints = _userRepository.GetFidelityPoints(id);
        int updatedPoints = currentPoints + points;
        _userRepository.SetFidelityPoints(id, updatedPoints);
        return updatedPoints;
    }
}