using E_Commerce.Context;
using E_Commerce.Interfaces;
using E_Commerce.Models;
using E_Commerce.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace E_Commerce.Controllers;

[ApiController]
[Route("products")]
public class ProductController : Controller

{
    protected readonly IProductRepository<Product> _repository;
    protected readonly IUpdateService<Product> _updateService;

    public ProductController(IProductRepository<Product> repository, IUpdateService<Product> updateService)
    {
        _repository = repository;
        _updateService = updateService;
    }

    [HttpGet("{id:int}")]
    public ActionResult<Product> GetById(int id)
    {
        Product? entity = _repository.GetById(id);

        if (entity == null) return NoContent();
        return entity;
    }

    [HttpGet]
    public IEnumerable<Product> GetAll()
    {
        return _repository.GetAll();
    }

    [HttpPost]
    public ActionResult<Product> Add([FromBodyAttribute]Product entity)
    {
        if (entity == null) return BadRequest();
        return _repository.Add(entity);
    }

    [HttpPut("{id:int}")]
    public ActionResult<Product> Update(int id, [FromBodyAttribute]Product updatedEntity){
        if (updatedEntity == null) return NoContent();

        Product? entity = _repository.Update(id, updatedEntity);
        if (entity == null) return NoContent();
        return entity;
    }

    [HttpDelete("{id:int}")]
    public ActionResult<Product> Delete(int id)
    {
        Product? entity = _repository.Delete(id);

        if (entity == null) return NoContent();
        return entity;
    }
}