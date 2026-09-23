using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;
namespace ProductApi.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    public UserService(AppDbContext context)
    {
        _context=context;
    }
    public async Task<User> AddAsync(User user)
    {
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