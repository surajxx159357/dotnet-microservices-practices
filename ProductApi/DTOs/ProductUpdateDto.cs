using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs;

public class ProductUpdateDto
{
    [Required]
    [StringLength(300)]
    public string Name{get;set;}=string.Empty;
    [Range(0.01,100000)]
    public decimal Price{get;set;}
    [Range(1,int.MaxValue)]
    public int Stock{get;set;}
}