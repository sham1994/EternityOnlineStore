using System.Linq;
using AutoMapper;
using EternityStore.Data.Model;
using EternityStore.Entity;

namespace EternityStore.API.Data.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            UserProfile();
            ProductCategoryProfile();
            ProductProfile();
            UserForLogin();
            UserForRegister();
            OrderProfile();

        }

        public void UserProfile()

        {
            // here specifies the source and the destination mapping
            // Automatter convention based
            //CreateMap<User, UserForListDto>()
            //    .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.UserPhotos.FirstOrDefault(p => p.IsMain).Url))
            //    .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            //CreateMap<User, UserForDetailDto>()
            //    .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.UserPhotos.FirstOrDefault(p => p.IsMain).Url))
            //    .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.UserPhotos.FirstOrDefault(p => p.IsMain).Url));
            CreateMap<User, UserForDetailDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.UserPhotos.FirstOrDefault(p => p.IsMain).Url));
            CreateMap<UserPhoto, UserPhotoForDetailDto>();
        }

        public void UserForLogin()
        {
            CreateMap<User, UserForLoginDto>().ReverseMap();
        }

        public void ProductCategoryProfile()
        {
            CreateMap<ProductCategory, ProductCategoryForListDto>()
            .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.CategoryPhotos.FirstOrDefault(p => p.IsMain).Url));
            CreateMap<ProductCategory, ProductCategoryForDetailDto>()
            .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.CategoryPhotos.FirstOrDefault(p=>p.IsMain).Url));
            CreateMap<ProductCategoryPhoto, ProductCategoryPhotoForDetailDto>();
            
            
        }

        public void ProductProfile()
        {
            CreateMap<Product, ProductForListDto>()
            .ForMember(dest => dest.PhotoUrl,opt =>  opt.MapFrom(src => src.ProductPhotos.FirstOrDefault(p => p.IsMain).Url ));
            CreateMap<Product, ProductForDetailDto>()
            .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.ProductPhotos.FirstOrDefault(p => p.IsMain).Url));
            CreateMap<ProductPhoto,ProductPhotoForDetailDto>();
        }

        public void OrderProfile()
        {
            //CreateMap<OrderForListDto, OrderHeader>().ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
            //CreateMap<OrderForDetailDto,OrderDetail>().ReverseMap();

            CreateMap<OrderForListDto, OrderHeader>();
            CreateMap<OrderForDetailDto, OrderDetail>().ReverseMap();
        }

        public void UserForRegister()
        {
            CreateMap<UserForRegisterDto, User>();
        }


    }
}