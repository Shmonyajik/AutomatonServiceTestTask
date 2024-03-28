using Contracts.Repository;
using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ProductRepository : RepositoryBase<StoreProducts>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            
        }
        public async Task<IEnumerable<StoreProducts>> GetAllProductsAsync()
        {
            return await FindAll()
               .OrderBy(p=>p.Id)
               .ToListAsync();
        }

        public async Task<StoreProducts> GetProductByIdAsync(int id)
        {
            return await FindByCondition(sp => sp.Id.Equals(id))
                .FirstOrDefaultAsync();
        }
        public async Task<StoreProducts> GetProductByIdWithDetailsAsync(int id)
        {
            return await FindByCondition(sp => sp.Id.Equals(id)).Include(sp => sp.Product)
                .FirstOrDefaultAsync();
        }

        public void CreateProduct(StoreProducts product)
        {
            Create(product);
        }
        public void UpdateProduct(StoreProducts product)
        {
            Update(product);
        }
        public void DeleteProduct(StoreProducts product)
        {
            Delete(product);
        }

        public Task<StoreProducts> GetProductWithDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
