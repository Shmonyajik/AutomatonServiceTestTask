using Contracts.Repository;
using Contracts.Services;
using Domain.Models;
using Domain.Responses;

namespace Services
{
    public class StoreService : IStoreService
    {
        private readonly  IRepositoryWrapper _repository;
        public StoreService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<Store>> GetStoreByIdAsync(int id)
        {
            var response = new BaseResponse<Store>();
            try
            {
                var store = await _repository.Store.GetStoreWithDetailsAsync(id);
                if(store == null)
                {
                    response.StatusCode=Domain.Enums.StatusCode.NotFound;
                    response.Message = $"Склад с id {id} не найден.";
                    return response;
                }
                response.StatusCode = Domain.Enums.StatusCode.OK;
                response.Data = store;
            }
            catch (Exception ex)
            {
                response.StatusCode = Domain.Enums.StatusCode.InternalServerError;
                response.Message = ex.Message;     
            }
            return response;
        }

        public async Task<BaseResponse<Store>> GetStoreByKeeperAsync(int keeperId)
        {
            var response = new BaseResponse<Store>();
            try
            {
                var store = await _repository.Store.GetStoreWithDetailsByKeeperIdAsync(keeperId);
                if (store == null)
                {
                    response.StatusCode = Domain.Enums.StatusCode.NotFound;
                    response.Message = $"Склад с id кладовщика {keeperId} не найден.";
                    return response;
                }
                response.Data = store;
                response.StatusCode = Domain.Enums.StatusCode.OK;
                
            }
            catch (Exception ex)
            {
                response.StatusCode = Domain.Enums.StatusCode.InternalServerError;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
