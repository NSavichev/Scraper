using AutoMapper;
using Domain.EF;
using Services.Contracts.Product;

namespace Services.Implementations.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности урока.
    /// </summary>
    public class ProductMappingsProfile : Profile
    {
        public ProductMappingsProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<CreatingProductDto, Product>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.Shop, map => map.Ignore())
                .ForMember(d => d.ShopId, map => map.MapFrom(m => m.ShopId))
                .ForMember(d => d.ProductUrl, map => map.Ignore())
                .ForMember(dest => dest.IdProduct2Shop, map => map.MapFrom(m => m.IdProduct2Shop))
                //.ForMember(d => d.DateTime, map => map.Ignore())
                .ForMember(d => d.Name, map => map.MapFrom(m=>m.Name))
                .ForMember(dest => dest.View, map => map.Ignore())
                .ForMember(dest => dest.Price, map => map.Ignore())
                .ForMember(dest => dest.CreateDate, map => map.Ignore())
                .ForMember(dest => dest.ScrapDate, map => map.Ignore())
                .ForMember(dest => dest.ScrapContent, map => map.Ignore());

            CreateMap<UpdatingProductDto, Product>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.Shop, map => map.Ignore())
                .ForMember(d => d.ShopId, map => map.Ignore())
                //.ForMember(d => d.DateTime, map => map.Ignore())
                .ForMember(d => d.Name, map => map.MapFrom(m => m.Name))
                .ForMember(dest => dest.IdProduct2Shop,map => map.Ignore())
                .ForMember(dest => dest.ProductUrl,map => map.Ignore())
                .ForMember(dest => dest.View,map => map.Ignore())
                .ForMember(dest => dest.Price,map => map.Ignore())
                .ForMember(dest => dest.CreateDate,map => map.Ignore())
                .ForMember(dest => dest.ScrapDate,map => map.Ignore())
                .ForMember(dest => dest.ScrapContent,map => map.Ignore());
            
            CreateMap<AttachingProductDto, Product>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.Shop, map => map.Ignore())
                .ForMember(d => d.ShopId, map => map.Ignore())
                //.ForMember(d => d.DateTime, map => map.Ignore())
                .ForMember(d => d.Name, map => map.MapFrom(m => m.Name))
                .ForMember(dest => dest.IdProduct2Shop,map => map.Ignore())
                .ForMember(dest => dest.ProductUrl,map => map.Ignore())
                .ForMember(dest => dest.View,map => map.Ignore())
                .ForMember(dest => dest.Price,map => map.Ignore())
                .ForMember(dest => dest.CreateDate,map => map.Ignore())
                .ForMember(dest => dest.ScrapDate,map => map.Ignore())
                .ForMember(dest => dest.ScrapContent,map => map.Ignore());
        }
    }
}
