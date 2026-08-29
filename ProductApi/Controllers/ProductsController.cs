using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Services;

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
    public IActionResult Add(Product product){
            if(product ==null){
                return BadRequest("product is required.");
            }
                           var result =_productservice.Add(product);
                           var result2=_productservice.GetAll();
            return Ok(result2);
    }
}