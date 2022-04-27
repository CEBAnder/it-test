using AutoMapper;

namespace it_test_consumer.Consumers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<it_test_shared_contracts.Models.User, Data.Models.User>();
        }
    }
}
