using Domain.Models;

namespace Contracts.Repository
{
    public interface IStoreRepository : IRepositoryBase<Store>
    {
        Task<IEnumerable<Store>> GetAllStoresAsync();
        Task<Store> GetStoreByIdAsync(int id);
        Task<Store> GetStoreWithDetailsAsync(int id);

        Task<Store> GetStoreWithDetailsByKeeperIdAsync(int keeperId);
        void CreateStore(Store store);
        void UpdateStore(Store store);
        void DeleteStore(Store store);
    }
}
