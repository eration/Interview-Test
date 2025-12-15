using Interview_Test.Models;
using Interview_Test.Repositories;
using Interview_Test.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Interview_Test.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("GetAllUsers")]
    public ActionResult GetAllUsers()
    {
        var users = _userRepository.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("GetUserById/{id}")]
    public ActionResult GetUserById(string id)
    {
        var user = _userRepository.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }


    
    [HttpPost("CreateUser")]
    public ActionResult CreateUser(UserModel user)
    {
        var affectedRows = _userRepository.CreateUser(user);
        return Ok(new { affectedRows });
    }
}