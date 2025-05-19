using Microsoft.EntityFrameworkCore;
using ProductAPI.models;

namespace ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext dbContext;

        public ProductRepository(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();


            return product;
        }

        public async Task<Product?> DeleteProductAsync(int productId)
        {

            var product = await dbContext.Products.FindAsync(productId);

            if (product == null)
            {
                return null;
            }

            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            var product = await dbContext.Products.FindAsync(productId);

            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async Task<Product?> UpdateProductAsync(Product product)
        {
            var existingProduct = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (existingProduct != null)
            {
                dbContext.Entry(existingProduct).CurrentValues.SetValues(product);
                await dbContext.SaveChangesAsync();
                return existingProduct;
            }

            return null;
        }
    }
}
