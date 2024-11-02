using AutoMapper;
using MinimalApiTest.Models;
using MinimalApiTest.Models.DTO;

namespace MinimalApiTest;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Coupon, CouponCreateDTO>().ReverseMap();
        CreateMap<Coupon, CouponDTO>().ReverseMap();
    }
}