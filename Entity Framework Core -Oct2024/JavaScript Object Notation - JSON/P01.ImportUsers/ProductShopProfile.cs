using AutoMapper;
using Microsoft.EntityFrameworkCore.Update;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile() 
        {
            CreateMap<User, UserImportModel>();
        }
    }
}
