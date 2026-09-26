using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Dtos;
using ProductApi.Models;
namespace ProductApi.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    private readonly ILogger<UserService> _logger;
    public UserService(AppDbContext context,ILogger<UserService> logger)
    {
        _context=context;
        _logger=logger;
    }
    public async Task<User?> AddAsync(RegisterDto registerdto)
    {
        // check for existing user
        var isExisting=await _context.Users.FirstOrDefaultAsync(x=>x.Username==registerdto.Username);
        if (isExisting != null)
        {
            _logger.LogError("User already exists");
           return null;
        }
        User user = new()
        {
            Username=registerdto.Username,
            PasswordHash=BCrypt.Net.BCrypt.HashPassword(registerdto.Password),
            Role="User"
        };
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task<User?> GetbyIdAsycn(int Id)
    {
        return await _context.Users
        .AsNoTracking()
        .FirstOrDefaultAsync(x=>x.Id==Id);
    }
}