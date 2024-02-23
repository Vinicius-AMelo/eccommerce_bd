using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace E_Commerce.Repositories
{
    public interface IProductRepository<T> where T : class
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        Product? Add(T entity);
        Product? Update(int id, T entity);
        Product? Delete(int id);
    }
}
