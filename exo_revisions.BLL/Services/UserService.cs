using exo_revisions.BLL.Interfaces;
using exo_revisions.BLL.Mappers;
using exo_revisions.BLL.Models;
using exo_revisions.DAL.Interfaces;

namespace exo_revisions.BLL.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHelper _passwordHelper;
    private readonly IJwtService _jwtService;

    public UserService(
        IUserRepository userRepository,
            IPasswordHelper passwordHelper,
                IJwtService jwtService)
    {
        _userRepository = userRepository;
            _passwordHelper = passwordHelper;
                _jwtService = jwtService;
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
        user.Email = user.Email.ToLower();

        string hash = _passwordHelper.GenerateHash(user.Email, user.Password);
        user.Password = hash;
        user.CreatedAt = DateTime.Now;

        return _userRepository.Create(user.ToEntity());
    }

    public string Login(string email, string rawPassword)
    {
        // 1) Récupérer l'user DB par email
        var dbUser = _userRepository.GetByEmail(email.ToLower()) ?? throw new Exception("User not found");

        // 2) Hasher le password fourni
        string hashInput = _passwordHelper.GenerateHash(email.ToLower(), rawPassword);

        // 3) Comparer avec la DB
        if (dbUser.Password != hashInput)
            throw new Exception("Invalid password");

        // 4) Si OK, générer un token JWT
        string token = _jwtService.GenerateJwtToken(dbUser.Id, dbUser.Email);

        // Renvoyer le token JWT
        return token;
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