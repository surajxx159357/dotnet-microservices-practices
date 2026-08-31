using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Services;
using ProductApi.DTOs;

namespace ProductApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductsController:ControllerBase{
    private readonly IProductService _productservice;
    public ProductsController(IProductService productservice){
        _productservice=productservice;
    }
    [HttpGet]
    public IActionResult GetAll(){
        var products=_productservice.GetAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id){
        var product =_productservice.GetById(id);
        if(product ==null)
        return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public IActionResult Add(ProductCreateDto dto){
            Product product = new()
            {
                Id=_productservice.GetAll().Count,
                Name=dto.Name,
                Price=dto.Price,
                Stock=dto.Stock
            };
            var createdproduct =_productservice.Add(product);
            return CreatedAtAction(nameof(GetById),new{Id=createdproduct.Id},createdproduct);
    }
}