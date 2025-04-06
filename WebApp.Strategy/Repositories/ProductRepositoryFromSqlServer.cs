using Microsoft.EntityFrameworkCore;
using WebApp.Strategy.Models;

namespace WebApp.Strategy.IRepositories
{
    public class ProductRepositoryFromSqlServer : IProductRepository
    {
        private readonly AppIdentityDbContext _identityDbContext;

        public ProductRepositoryFromSqlServer(AppIdentityDbContext identityDbContext)
        {
            _identityDbContext = identityDbContext;
        }

        public async Task Delete(Product product)
        {
            _identityDbContext.Products.Remove(product);
            await _identityDbContext.SaveChangesAsync();
        }

        public Task<List<Product>> GetAllByUserId(string userId)
        {
            return _identityDbContext.Products.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Product> GetById(string id)
        {
            return await _identityDbContext.Products.FindAsync(id);
        }

        public async Task<Product> Save(Product product)
        {
            product.Id=Guid.NewGuid().ToString();
            await _identityDbContext.Products.AddAsync(product);
            await _identityDbContext.SaveChangesAsync();
            return product;
        }

        public async Task Update(Product product)
        {
            _identityDbContext.Update(product);
            await _identityDbContext.SaveChangesAsync();
        }
    }
}
