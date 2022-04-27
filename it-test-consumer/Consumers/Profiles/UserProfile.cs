using AutoMapper;
using it_test_consumer.Data.Models;
using it_test_shared_contracts.Models;

namespace it_test_consumer.Consumers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, OrgUser>();
        }
    }
}
