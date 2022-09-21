using Catolog.API.Data;
using Catolog.API.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catolog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ICatalogContext _context { get; }

        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task createProduct(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            var updatedResutl = await _context.Products.DeleteOneAsync(filter);
            return updatedResutl.IsAcknowledged && updatedResutl.DeletedCount > 0;
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.Find(p => true).ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updatedResutl = await _context.Products.ReplaceOneAsync(p => p.Id == product.Id, product);
            return updatedResutl.IsAcknowledged && updatedResutl.ModifiedCount > 0;
        }
    }
}
