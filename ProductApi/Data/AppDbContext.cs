namespace ProductApi.Data;
using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options){

    }
    public DbSet<Product> Products{get;set;}
    public DbSet<User> Users{get;set;}
}