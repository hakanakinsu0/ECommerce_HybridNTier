using AutoMapper;
using Project.Bll.DtoClasses;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Sen AppUser'i, AppUserDto'ya maple ve gerekirse tam tersi seklinde de maple demis oluyoruz. Yani ayni sekilde tersine maplemeyi de yap.
            CreateMap<AppUser, AppUserDto>() .ReverseMap();
            CreateMap<AppUserProfile, AppUserProfileDto>() .ReverseMap();
            CreateMap<Category, CategoryDto>() .ReverseMap();
            CreateMap<Product, ProductDto>() .ReverseMap();
            CreateMap<Order, OrderDto>() .ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>() .ReverseMap();
        }
    }
}
