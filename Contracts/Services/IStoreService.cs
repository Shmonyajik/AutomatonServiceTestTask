using Domain.Models;
using Domain.Responses;

namespace Contracts.Services
{
    public interface IStoreService
    {
        Task<BaseResponse<Store>> GetStoreByIdAsync(int id);

        Task<BaseResponse<Store>> GetStoreByKeeperAsync(int keeperId);
    }
}
