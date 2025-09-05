using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataDemo.Data;
using ODataDemo.Models;

namespace ODataDemo.Controllers;

public class OrdersController : ODataController
{
    private readonly AppDbContext _context;

    public OrdersController(AppDbContext context) =>
        _context = context;

    [EnableQuery]
    public IQueryable<Order> Get() =>
        _context.Orders;

    [EnableQuery]
    public IActionResult Get(int key)
    {
        var product = _context.Orders.FirstOrDefault(p => p.Id == key);

        if (product == null)
            return NotFound();

        return Ok(product);
    }
}
