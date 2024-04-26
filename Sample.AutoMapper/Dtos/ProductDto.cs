using AutoMapper;
using Sample.AutoMapper.Entities;

namespace Sample.AutoMapper.Dtos;
public class ProductDto
{
    public int ProductId { get; set; }
    public double Price { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public string ProductType { get; set; }
}

public class ProductDtoProfiles : Profile
{
    public ProductDtoProfiles()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.ProductName,
                src => src.MapFrom(s => $"Name Is : {s.Name}"))
            .ForMember(dest => dest.ProductDescription,
                src => src.MapFrom(s => $"Des : {s.Description}"))
            .ForMember(dest => dest.ProductId,
                src => src.MapFrom(s => s.Id))
            .ReverseMap()
            .ForMember(dest => dest.Name,
                src => src.MapFrom(c => c.ProductName))
            .ForMember(dest => dest.Description,
                src => src.MapFrom(c => c.ProductName))
            .ForMember(dest => dest.Price,
                src => src.MapFrom(c => c.Price + 10));

    }
}