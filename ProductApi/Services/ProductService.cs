using ProductApi.Models;
using ProductApi.Services;

public class ProductService:IProductService
{
    private readonly List<Product> _lstproducts = new()
    {
        new Product()
        {
            Id=1,
            Name="Laptop",
            Price=50000,
            Stock=10
        },
        new Product()
        {
            Id=2,
            Name="Keyboard",
            Price=2000,
            Stock=5
        }
    };
    public List<Product>GetAll()
    {
        return _lstproducts;
    }

    public Product? GetById(int Id)
    {
        return _lstproducts.FirstOrDefault(x=>x.Id==Id);
    }

    public Product Add(Product product)
    {
        product.Id=_lstproducts.Count+1;
        _lstproducts.Add(product);
        return product;
    }
}