using AutoMapper;
using Services.Contracts.Shop;
using WebApi.Models.Shop;

namespace WebApi.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности магазина.
    /// </summary>
    public class ShopMappingsProfile : Profile
    {
        public ShopMappingsProfile()
        {
            CreateMap<ShopDto, ShopModel>()
             .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
            CreateMap<CreatingShopModel, CreatingShopDto>()
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.ShopId, opt => opt.Ignore())
                .ForMember(dest => dest.ShopUrl, opt => opt.Ignore())
                .ForMember(dest => dest.IsAllScrap, opt => opt.Ignore());
            CreateMap<UpdatingShopModel, UpdatingShopDto>()
                .ForMember(dest => dest.ShopUrl, opt => opt.MapFrom(src => src.ShopUrl));
            CreateMap<ShopFilterModel, ShopFilterDto>();
            CreateMap<UpdatingShopWithProductModel, UpdatingShopWithProductsDto>()
                .ForMember(dest => dest.ShopUrl, opt => opt.MapFrom(src => src.ShopUrl));
            //CreateMap<ShopInfoDto, ProductInfoModel>();
        }
    }
}
