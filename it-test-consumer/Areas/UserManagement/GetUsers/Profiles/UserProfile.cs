using AutoMapper;
using it_test_consumer.Data.Models;

namespace it_test_consumer.Areas.UserManagement.GetUsers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetUsersResponse>()
                .ForMember(dst => dst.OrgName, opt => opt.MapFrom(src => src.Organisation != null ? src.Organisation.Name : null));
        }
    }
}
