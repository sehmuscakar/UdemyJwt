using AutoMapper;
using UdemyJwt.Back.Core.Application.Dto;
using UdemyJwt.Back.Core.Domain;

namespace UdemyJwt.Back.Core.Application.Mappings
{
    public class ProductProfile : Profile
    {
       public ProductProfile()
        {
            this.CreateMap<Product, ProductListDto>().ReverseMap();
        }
    }
}
