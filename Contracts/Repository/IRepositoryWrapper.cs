using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IRepositoryWrapper
    {
        IProductRepository Product { get; }
        IStoreRepository Store { get; }
        Task SaveAsync();
    }
}
