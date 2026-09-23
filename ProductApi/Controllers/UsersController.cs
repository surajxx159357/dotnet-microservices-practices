using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.DTOs;
using ProductApi.Services;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userservice;
    public UsersController(IUserService userService)
    {
        _userservice=userService;
    }

    public async Task<IActionResult> GetAll()
    {
        List<User> lstusers= await _userservice.GetAllAsync();
        return Ok(lstusers);
    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(int Id)
    {
        var user=await _userservice.GetbyIdAsycn(Id);
        return Ok(user);
    }
    [HttpPost]
    public async Task<IActionResult> Add(UserCreateDto usr)
    {
        User user = new()
        {
            Name=usr.Name,
            Role=usr.Role,
            Email=usr.Email
        };
        var createduser=await _userservice.AddAsync(user);
        return CreatedAtAction(nameof(GetById),new {Id=createduser.Id},user);
    }
}