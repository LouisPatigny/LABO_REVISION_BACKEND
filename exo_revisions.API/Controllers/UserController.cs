using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using exo_revisions.API.DTOs;
using exo_revisions.API.Mappers;
using exo_revisions.BLL.Interfaces;
using exo_revisions.BLL.Models;

namespace exo_revisions.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetAll()
    {
        try
        {
            IEnumerable<UserDTO> users = _userService.GetAll().Select(u => u.ToDTO());
            return Ok(users);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("id/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetById(int id)
    {
        try
        {
            UserDTO? user = _userService.GetById(id)?.ToDTO();
            if (user == null)
            {
                return NotFound("L'utilisateur n'existe pas");
            }
            return Ok(user);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpGet("email/{email}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetByEmail(string email)
    {
        try
        {
            UserDTO? user = _userService.GetByEmail(email)?.ToDTO();
            if (user == null)
            {
                return NotFound("L'utilisateur n'existe pas");
            }
            return Ok(user);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("points/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetFidelityPoints(int id)
    {
        try
        {
            return Ok(_userService.GetFidelityPoints(id));
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("points/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult UpdateFidelityPoints(int id, int points)
    {
        try
        {
            return Ok(_userService.UpdateFidelityPoints(id, points));
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserCreateDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create([FromBody] UserCreateDTO user)
    {
        int resultId = _userService.Create(user.ToModel());
        if (resultId > 0)
        {
            return CreatedAtAction(nameof(GetById), new {id = resultId}, user);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Login ([FromBody] UserLoginDTO user)
    {
        try
        {
            string? token = _userService.Login(user.Email, user.Password);
            return Ok(new { token });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}

