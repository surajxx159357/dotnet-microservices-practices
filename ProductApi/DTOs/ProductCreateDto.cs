using System.ComponentModel.DataAnnotations;
namespace ProductApi.DTOs;
public class ProductCreateDto
{   
    [Required]
    [StringLength(100)]
    public string Name{get;set;}=string.Empty;
    [Range(0.01,1000000)]
    public Decimal Price{get;set;}
    [Range(0,int.MaxValue)]
    public int Stock{get;set;}
}