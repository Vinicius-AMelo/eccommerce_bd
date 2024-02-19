using E_Commerce.Context;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;


namespace E_Commerce.Controllers;

[ApiController]
[Route("products")]
public class ProductController : Controller

{
    protected readonly StudyContext _context;

    public ProductController(StudyContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Product> GetAll()
    {
        return _context.Set<Product>().ToArray();
    }

    [HttpPost]
    public Product Add(Product entity)
    {
        _context.Set<Product>().Add(entity);
        _context.SaveChanges();
        return entity;
    }

    [HttpDelete]
    public ActionResult<Product> Delete(int id)
    {
        Product entity = _context.Set<Product>().Find(id);
        if (entity == null) return NoContent();

        _context.Set<Product>().Remove(entity);
        _context.SaveChanges();
        return Ok();
    }
}