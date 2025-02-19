using AutoMapper;
using Project.Bll.DtoClasses;
using Project.MvcUI.Areas.Admin.Models.PureVms.RequestModels;
using Project.MvcUI.Areas.Admin.Models.PureVms.ResponseModels;

namespace Project.MvcUI.VmMapping
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {
            CreateMap<CreateCategoryRequestModel, CategoryDto>(); 
            CreateMap<UpdateCategoryRequestModel, CategoryDto>();
            CreateMap<CategoryDto, CategoryResponseModel>();
        }
    }
}
