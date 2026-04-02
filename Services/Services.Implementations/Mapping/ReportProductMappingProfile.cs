using AutoMapper;
using Domain.EF;
using Services.Contracts.Product;
using Services.Contracts.ReportProduct;
using Services.Contracts.Shop;

namespace Services.Implementations.Mapping
{
    public class ReportProductMappingProfile : Profile
    {
        public ReportProductMappingProfile()
        {
            CreateMap<ReportProduct, ReportProductDto>();
            CreateMap<CreatingReportProductDto, ReportProduct>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(dest => dest.IdProduct, opt => opt.MapFrom(src => src.IdProduct));
            CreateMap<UpdatingReportProductDto, ReportProduct>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(dest => dest.IdProduct, opt => opt.MapFrom(src => src.IdProduct));
        }
    }
}
