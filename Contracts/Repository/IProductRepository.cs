using Domain.Models;

namespace Contracts.Repository
{
    public interface IProductRepository : IRepositoryBase<Product>
    {

        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> GetProductWithDetailsAsync(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
