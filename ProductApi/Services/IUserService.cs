using ProductApi.Dtos;
using ProductApi.Models;
namespace ProductApi.Services;
public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<User?>GetbyIdAsycn(int Id);
    Task<User?>AddAsync(RegisterDto registerDto);
}