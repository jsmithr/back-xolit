using AutoMapper;
using XolitTest.Model.Entity;
using XolitTest.Model.Dto;


namespace XolitTest.Model.Mapper
{
    public class InvoiceMapper : Profile
    {
        public InvoiceMapper()
        {
            CreateMap<Invoice, InvoiceDto>()
                .ForMember(
                    dest => dest.NumeroFactura,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ReverseMap();

            CreateMap<DetailInvoice, DetailInvoiceDto>().ReverseMap();
        }
    }
}
