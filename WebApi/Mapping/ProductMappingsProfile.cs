using AutoMapper;
using Services.Contracts.Product;
using WebApi.Models.Product;

namespace WebApi.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности продукта.
    /// </summary>
    public class ProductMappingsProfile : Profile
    {
        public ProductMappingsProfile()
        {
            CreateMap<ProductDto, ReportProductModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<CreatingProductModel, CreatingProductDto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<UpdatingProductModel, UpdatingProductDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<AttachingProductModel, AttachingProductDto>()
                .ForMember(dest => dest.ShopId, opt => opt.MapFrom(src => src.Name));
        }
    }
}
