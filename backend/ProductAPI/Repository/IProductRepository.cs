using ProductAPI.models;

namespace ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<Product> CreateProductAsync(Product product);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int productId);
        Task<Product?> UpdateProductAsync(Product product);
        Task<Product?> DeleteProductAsync(int productId);
    }
}
