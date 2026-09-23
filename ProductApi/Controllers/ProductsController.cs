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
    public async Task<IActionResult> GetAll(){
        var products=await _productservice.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id){
        var product =await _productservice.GetByIdAsync(id);
        if(product ==null)
        return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductCreateDto dto){
            Product product = new()
            {
                Name=dto.Name,
                Price=dto.Price,
                Stock=dto.Stock
            };
            var createdproduct =await _productservice.AddAsync(product);
            return CreatedAtAction(nameof(GetById),new{Id=createdproduct.Id},createdproduct);
    }
    [HttpPut("{Id}")]
    public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto,int Id)
    {
        // var producttobeupdated=await _productservice.GetByIdAsync(Id);
        // // above line fetch the product corresponding to the id and keep tracks of the product
        // producttobeupdated.Name=productUpdateDto.Name;
        // producttobeupdated.Price=productUpdateDto.Price;
        // producttobeupdated.Stock=productUpdateDto.Stock;
        // var result=await _productservice.UpdateAsync(producttobeupdated);
        //we'll avoid this,because keeping business login and db code in service is much better than keeping it in controller
        var result =await _productservice.UpdateAsync(Id,productUpdateDto);
        if(result==null)
        return NotFound();
        
        return Ok(result);
    }
    [HttpDelete("{Id}")]
    public async Task<IActionResult>DeleteAsync(int Id)
    {
        bool isdeleted=await _productservice.DeleteAsync(Id);
        if (!isdeleted)
        {
            return NotFound();
        }
        return NoContent();
    }
    [HttpGet("test-error")]
    public async Task<IActionResult> TestError()
    {
        throw new Exception("this is a custom error for testing.");
    }
}