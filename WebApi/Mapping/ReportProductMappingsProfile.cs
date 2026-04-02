using AutoMapper;
using Services.Contracts.ReportProduct;
using WebApi.Models.ReportProduct;

namespace WebApi.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности продукта.
    /// </summary>
    public class ReportProductMappingsProfile : Profile
    {
        public ReportProductMappingsProfile()
        {
            CreateMap<ReportProductDto, ReportProductModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<CreatingReportProductModel, CreatingReportProductDto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<UpdatingReportProductModel, UpdatingReportProductDto>()
                .ForMember(dest => dest.IdProduct, opt => opt.MapFrom(src => src.IdProduct));
        }
    }
}
