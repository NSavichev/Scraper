using AutoMapper;
using Domain.EF;
using Services.Contracts.Shop;

namespace Services.Implementations.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности магазина.
    /// </summary>
    public class ShopMappingsProfile : Profile
    {
        public ShopMappingsProfile()
        {
            CreateMap<Shop, ShopDto>();
            
            CreateMap<CreatingShopDto, Shop>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
				.ForMember(d => d.Products, map => map.Ignore())
				.ForMember(d => d.IsAllScrap, map => map.Ignore())
				.ForMember(d => d.Name, map => map.Ignore())
				.ForMember(d => d.ShopUrl, map => map.Ignore())
				.ForMember(d => d.ShopId, map => map.Ignore());
            
            CreateMap<UpdatingShopDto, Shop>()
				.ForMember(d => d.Id, map => map.Ignore())
				.ForMember(d => d.Deleted, map => map.Ignore())
				.ForMember(d => d.Products, map => map.Ignore())
				.ForMember(d => d.IsAllScrap, map => map.Ignore())
				.ForMember(d => d.Name, map => map.Ignore())
				.ForMember(d => d.ShopUrl, map => map.Ignore())
				.ForMember(d => d.ShopId, map => map.Ignore());

			CreateMap<UpdatingShopWithProductsDto, Shop>()
				.ForMember(d => d.Id, map => map.Ignore())
				.ForMember(d => d.Deleted, map => map.Ignore())
				.ForMember(d => d.Products, map => map.Ignore())
				.ForMember(d => d.IsAllScrap, map => map.Ignore())
				.ForMember(d => d.Name, map => map.Ignore())
				.ForMember(d => d.ShopUrl, map => map.Ignore())
				.ForMember(d => d.ShopId, map => map.Ignore());

		}
    }
}
