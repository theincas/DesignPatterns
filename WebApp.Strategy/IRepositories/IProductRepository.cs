using WebApp.Strategy.Models;

namespace WebApp.Strategy.IRepositories
{
    public interface IProductRepository
    {
        Task<Product> GetById(string id);
        Task<List<Product>> GetAllByUserId(string userId);
        Task<Product> Save(Product product);
        Task Update(Product product);
        Task Delete(Product product);
    }
}
