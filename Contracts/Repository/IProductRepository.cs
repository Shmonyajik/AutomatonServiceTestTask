using Domain.Models;

namespace Contracts.Repository
{
    public interface IProductRepository : IRepositoryBase<StoreProducts>
    {

        Task<IEnumerable<StoreProducts>> GetAllProductsAsync();
        Task<StoreProducts> GetProductByIdAsync(int id);
        Task<StoreProducts> GetProductByIdWithDetailsAsync(int id);
        void CreateProduct(StoreProducts product);
        void UpdateProduct(StoreProducts product);
        void DeleteProduct(StoreProducts product);
    }
}
