using AutoMapper;
using Ecommerce.Data.DTOs;
using Ecommerce.Data.DTOs.CategoryDtos;
using Ecommerce.Data.DTOs.ProductDtos;
using Ecommerce.Data.Entities;

namespace Ecommerce.Application.Profiles
{

    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<UserProfile>();
                


            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<BlockDto, Block>();
            CreateMap<BlockDto, Block>().ReverseMap();

            CreateMap<CategoryInsertDto, Category>();
            CreateMap<CategoryInsertDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
            CreateMap<CategoryDeleteDto, Category>();
            CreateMap<CategoryDeleteDto, Category>().ReverseMap();
            CreateMap<CategoryDto, Category>();
            CreateMap<CategoryDto, Category>().ReverseMap();

            CreateMap<ProductDto, Product>();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductInsertDto, Product>();
            CreateMap<ProductInsertDto, Product>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();
            CreateMap<ProductDeleteDto, Product>();
            CreateMap<ProductDeleteDto, Product>().ReverseMap();

            CreateMap<VendorDto, Vendor>();
            CreateMap<VendorDto, Vendor>().ReverseMap();
            CreateMap<VendorUpdateDto, Vendor>();
            CreateMap<VendorUpdateDto, Vendor>().ReverseMap();
            CreateMap<VendorInsertDto, Vendor>();
            CreateMap<VendorInsertDto, Vendor>().ReverseMap();
            CreateMap<VendorDeleteDto, Vendor>();
            CreateMap<VendorDeleteDto, Vendor>().ReverseMap();

            CreateMap<CartDto, Cart>();
            CreateMap<CartDto, Cart>().ReverseMap();
            CreateMap<CartUpdateDto, Cart>();
            CreateMap<CartUpdateDto, Cart>().ReverseMap();
            CreateMap<CartInsertDto, Cart>();
            CreateMap<CartInsertDto, Cart>().ReverseMap();
            CreateMap<CartDeleteDto, Cart>();
            CreateMap<CartDeleteDto, Cart>().ReverseMap();
        }
    }
}
