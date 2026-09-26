using System.ComponentModel.DataAnnotations;
namespace ProductApi.DTOs;

public class UserCreateDto{
    [Required]
    [StringLength(300)]
    public string Name{get;set;}=string.Empty;
    [Required]
    [StringLength(50)]
    public string Role{get;set;}=string.Empty;
    [Required]
    [EmailAddress]
    [StringLength(200)]
    public string PasswordHash{get;set;}=string.Empty;
}