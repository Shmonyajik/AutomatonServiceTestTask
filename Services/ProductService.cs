using AutoMapper;
using Contracts.Repository;
using Contracts.Services;
using Domain.Models;
using Domain.Responses;

namespace Services
{
    public class ProductService: IProductService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        public ProductService(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<BaseResponse<bool>> EditProductAsync(StoreProducts product)
        {
            var response = new BaseResponse<bool>();
            try
            {
                //ValidateProduct(product);
                var productEntity = await _repository.Product.GetProductByIdWithDetailsAsync(product.Id);
                if(productEntity==null)
                {
                    response.StatusCode=Domain.Enums.StatusCode.NotFound;
                    response.Message = $"Товар с id {product.Id} не найден.";
                    return response;
                }
                _mapper.Map(product, productEntity);
                _repository.Product.UpdateProduct(productEntity);
                
                await _repository.SaveAsync();
                response.StatusCode = Domain.Enums.StatusCode.OK;
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.StatusCode = Domain.Enums.StatusCode.InternalServerError;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<BaseResponse<IEnumerable<int>>> EditProductsAsync(IEnumerable<StoreProducts> products)
        {
            var response = new BaseResponse<IEnumerable<int>>();
            try
            {
                var notFoundIds = new List<int>();

                foreach (var product in products)
                {
                    //ValidateProduct(product);
                    var productEntity = await _repository.Product.GetProductByIdWithDetailsAsync(product.Id);
                    if(productEntity==null)
                    {
                        notFoundIds.Add(product.Id);
                        continue;
                    }
                    _repository.Product.UpdateProduct(product);
                }
                if(notFoundIds.Count>0)
                {
                    response.Message = "Не найдены товары со следующими идентификаторами: ";
                    response.Data = notFoundIds;
                }
                await _repository.SaveAsync();
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
