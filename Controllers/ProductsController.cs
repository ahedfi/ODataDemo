using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataDemo.Data;
using ODataDemo.Models;

namespace ODataDemo.Controllers;

public class ProductsController : ODataController
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context) =>
        _context = context;

    [EnableQuery]
    public IQueryable<Product> Get() =>
        _context.Products;

    [EnableQuery]
    public IActionResult Get(int key)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == key);
        
        if (product == null) 
            return NotFound();
        
        return Ok(product);
    }
}
