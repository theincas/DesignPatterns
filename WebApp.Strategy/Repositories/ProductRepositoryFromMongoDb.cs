using MongoDB.Driver;
using WebApp.Strategy.IRepositories;
using WebApp.Strategy.Models;

namespace WebApp.Strategy.Repositories
{
    public class ProductRepositoryFromMongoDb : IProductRepository
    {
        private readonly IMongoCollection<Product> _mongoCollection;

        public ProductRepositoryFromMongoDb(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDb");
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ProductDb"); //yoksa sıfırdan oluşturur
            _mongoCollection = database.GetCollection<Product>("Products");
        }

        public async Task Delete(Product product)
        {
            await _mongoCollection.DeleteOneAsync(x => x.Id == product.Id);
        }

        public async Task<List<Product>> GetAllByUserId(string userId)
        {
            return await _mongoCollection.Find(x=>x.UserId==userId).ToListAsync();
        }

        public Task<Product> GetById(string id)
        {
            return _mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Product> Save(Product product)
        {
            await _mongoCollection.InsertOneAsync(product);
            return product;
        }

        public async Task Update(Product product)
        {
            await _mongoCollection.FindOneAndReplaceAsync(x => x.Id == product.Id, product);
        }
    }
}
