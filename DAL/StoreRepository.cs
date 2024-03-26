using Contracts.Repository;
using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class StoreRepository : RepositoryBase<Store>, IStoreRepository
    {
        public StoreRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
        public async Task<IEnumerable<Store>> GetAllStoresAsync()
        {
            return await FindAll()
               .ToListAsync();
        }
        public async Task<Store> GetStoreByIdAsync(int id)
        {
            return await FindByCondition(Store => Store.Id.Equals(id))
                .FirstOrDefaultAsync();
        }
        public async Task<Store> GetStoreWithDetailsAsync(int id)
        {
            return await FindByCondition(Store => Store.Id.Equals(id))
                .Include(st=>st.Keeper)
                .Include(st => st.Products)
                .FirstOrDefaultAsync();
        }

        public async Task<Store>GetStoreWithDetailsByKeeperIdAsync(int keeperId)
        {
            return await FindByCondition(Store => Store.KeeperId.Equals(keeperId))
                .Include(st => st.Keeper)
                .Include(st => st.Products)
                .FirstOrDefaultAsync();
        }
        public void CreateStore(Store store)
        {
            Create(store);
        }
        public void UpdateStore(Store store)
        {
            Update(store);
        }
        public void DeleteStore(Store store)
        {
            Delete(store);
        }

    }
}
