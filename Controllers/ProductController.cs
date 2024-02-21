using E_Commerce.Context;
using E_Commerce.Interfaces;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;


namespace E_Commerce.Controllers;

[ApiController]
[Route("products")]
public class ProductController : Controller

{
    protected readonly StudyContext _context;
    protected readonly IUpdateService<Product> _updateService;

    public ProductController(StudyContext context, IUpdateService<Product> updateService)
    {
        _context = context;
        _updateService = updateService;
    }

    [HttpGet("{id:int}")]
    public ActionResult<Product> GetById(int id)
    {
        Product entity = _context.Set<Product>().Find(id);

        if (entity == null) return NoContent();
        return entity;
    }

    [HttpGet]
    public IEnumerable<Product> GetAll()
    {
        return _context.Set<Product>().ToArray();
    }

    [HttpPost]
    public Product Add([FromBodyAttribute]Product entity)
    {
        _context.Set<Product>().Add(entity);
        _context.SaveChanges();
        return entity;
    }

    [HttpPut("{id:int}")]
    public ActionResult<Product> Update(int id, [FromBodyAttribute]Product entity){
        if (entity == null) return NoContent();

        Product existingProduct = _context.Set<Product>().Find(id);
        if (existingProduct == null) return NoContent();

        Product updatedEntity = _updateService.UpdateEntity(existingProduct, entity);
        _context.Update(updatedEntity);
        _context.SaveChanges();
        return updatedEntity;
    }

    [HttpDelete("{id:int}")]
    public ActionResult<Product> Delete(int id)
    {
        Product entity = _context.Set<Product>().Find(id);

        if (entity == null) return NoContent();
        _context.Set<Product>().Remove(entity);
        _context.SaveChanges();
        return Ok();
    }
}