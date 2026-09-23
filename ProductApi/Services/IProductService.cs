using ProductApi.DTOs;
using ProductApi.Models;
namespace ProductApi.Services;
public interface IProductService
{
    Task<List<Product>>GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> AddAsync(Product product);
    // Task<Product>UpdateAsync(Product product);
    Task<Product?>UpdateAsync(int Id,ProductUpdateDto productUpdateDto);
    Task<bool>DeleteAsync(int Id);

}