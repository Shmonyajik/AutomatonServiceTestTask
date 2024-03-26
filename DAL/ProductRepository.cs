using Contracts.Repository;
using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await FindAll()
               .OrderBy(p=>p.Name)
               .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await FindByCondition(Product => Product.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public void CreateProduct(Product product)
        {
            Create(product);
        }
        public void UpdateProduct(Product product)
        {
            Update(product);
        }
        public void DeleteProduct(Product product)
        {
            Delete(product);
        }

        public Task<Product> GetProductWithDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
