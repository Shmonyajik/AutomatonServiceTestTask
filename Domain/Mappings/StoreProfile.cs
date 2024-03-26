using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappings
{
    public class StoreProfile: Profile
    {
        public StoreProfile()
        {
            CreateMap<Keeper, Keeper>();
            CreateMap<Store, Keeper>();
            CreateMap<Product, Product>();  
        }
    }
}
