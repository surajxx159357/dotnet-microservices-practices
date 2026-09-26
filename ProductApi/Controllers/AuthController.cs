using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.DTOs;
using ProductApi.Services;
using ProductApi.Dtos;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userservice;
    public AuthController(IUserService userService)
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
    public async Task<IActionResult> Add(RegisterDto usr)
    {
        var createduser=await _userservice.AddAsync(usr);
        if(createduser ==null){
            return BadRequest("User already exists.");
        }
        return CreatedAtAction(nameof(GetById),new {Id=createduser.Id},usr);
    }
}