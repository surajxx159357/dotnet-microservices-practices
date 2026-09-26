using Microsoft.EntityFrameworkCore;
using ProductApi.Models;
using ProductApi.Services;
using ProductApi.Data;
using ProductApi.DTOs;

public class ProductService:IProductService
{   
    private readonly AppDbContext _context;
    private readonly ILogger<ProductService> _logger;
    // private readonly List<Product> _lstproducts = new()
    // {
    //     new Product()
    //     {
    //         Id=1,
    //         Name="Laptop",
    //         Price=50000,
    //         Stock=10
    //     },
    //     new Product()
    //     {
    //         Id=2,
    //         Name="Keyboard",
    //         Price=2000,
    //         Stock=5
    //     }
    // };
    public ProductService(AppDbContext context,ILogger<ProductService> logger){
        _context=context;
        _logger=logger;
    }
    public async Task<List<Product>>GetAllAsync()
    {
        _logger.LogInformation("All records fetched successfully.");
        return await _context.Products.AsNoTracking().ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int Id)
    {
        _logger.LogInformation("Fetching the record for {id}",Id);
        
        var product=await _context.Products.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==Id);
        if(product==null){
            _logger.LogWarning("Product for Id - {Id} is not found",Id);
        }
        return product;
    }

    public async Task<Product> AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> UpdateAsync(int Id,ProductUpdateDto productUpdateDto)
    {
        // _context.Products.Update(product);
        // await _context.SaveChangesAsync();
        var product=await _context.Products.FirstOrDefaultAsync(x=>x.Id==Id);
        if(product==null){
            _logger.LogError("Product is Not Found for updation.");
            return null;}
        product.Name=productUpdateDto.Name;
        product.Price=productUpdateDto.Price;
        product.Stock=productUpdateDto.Stock;
         _context.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }
    public async Task<bool>DeleteAsync(int Id)
    {
        bool isDeleted=false;
        var product=await this.GetByIdAsync(Id);
        if(product==null){
            _logger.LogInformation("No product is found against this id for deletion.");
        }
         _context.Products.Remove(product);
         isDeleted=await _context.SaveChangesAsync()>0;
         return isDeleted;
    }
}