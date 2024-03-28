using Domain.Models;
using Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IProductService
    {
        Task<BaseResponse<bool>> EditProductAsync(StoreProducts product);
        Task<BaseResponse<IEnumerable<int>>> EditProductsAsync(IEnumerable<StoreProducts> products);


    }
}
