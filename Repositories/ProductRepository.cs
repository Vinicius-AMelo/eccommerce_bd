using E_Commerce.Context;
using E_Commerce.Interfaces;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_Commerce.Repositories
{
    public class ProductRepository : IProductRepository<Product>
    {
        private StoreContext _context;
        private IUpdateService<Product> _updateService;

        public ProductRepository(StoreContext context, IUpdateService<Product> updateService)
        {
            _context = context;
            _updateService = updateService;
        }

        public Product? GetById(int id)
        {
            return _context.Set<Product>().Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Set<Product>().ToArray();
        }

        public Product Add(Product entity)
        {
            _context.Set<Product>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Product? Update(int id, Product entity)
        {
            Product? existingProduct = _context.Set<Product>().Find(id);
            if (existingProduct == null) return existingProduct;

            Product updatedEntity = _updateService.UpdateEntity(existingProduct, entity);
            _context.Update(updatedEntity);
            _context.SaveChanges();
            return updatedEntity;
        }

        public Product? Delete(int id)
        {
            Product? entity = _context.Set<Product>().Find(id);
            if (entity == null) return entity;

            _context.Set<Product>().Remove(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
