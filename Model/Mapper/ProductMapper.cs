using AutoMapper;
using XolitTest.Model.Entity;
using XolitTest.Model.Dto;


namespace XolitTest.Model.Mapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
