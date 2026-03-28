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
            CreateMap<ProductDto, ProductModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ShopId, opt => opt.Ignore());
            CreateMap<CreatingProductModel, CreatingProductDto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ShopId, opt => opt.MapFrom(src => src.ShopId))
                .ForMember(dest => dest.IdProduct2Shop, opt => opt.MapFrom(src => src.IdProduct2Shop))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
    .ForMember(dest => dest.Price, opt => opt.Ignore())
    .ForMember(dest => dest.View, opt => opt.Ignore())
    .ForMember(dest => dest.ProductUrl, opt => opt.Ignore()); ;
            CreateMap<UpdatingProductModel, UpdatingProductDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<AttachingProductModel, AttachingProductDto>()
                .ForMember(dest => dest.ShopId, opt => opt.MapFrom(src => src.Name));
        }
    }
}
