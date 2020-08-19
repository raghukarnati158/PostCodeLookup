using AutoMapper;
using PostCodeLookupAPI.Entities;
using PostCodeLookupAPI.Models;

namespace PostCodeLookupAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
        }
    }
}
