using AutoMapper;
using Ecommerce.Data.DTOs;
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
        }
    }
}
