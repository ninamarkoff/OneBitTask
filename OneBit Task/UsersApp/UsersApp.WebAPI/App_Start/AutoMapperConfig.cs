namespace UsersApp.WebAPI
{
    using UserApp.DBModels.DBModels;
    using ViewModels;

    using AutoMapper;

    public class AutoMapperConfig
    {
        public static void Configure()
        {

            Mapper.CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(s => s.Gender.Description))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(s => s.Status.Description))
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(s => s.PhotoUrl));

            Mapper.CreateMap<UserViewModel, User>()
               .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(s => s.Photo));
        }
    }
}