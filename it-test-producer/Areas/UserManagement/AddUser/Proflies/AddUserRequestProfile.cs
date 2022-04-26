using AutoMapper;
using it_test_shared_contracts.Models;

namespace it_test_producer.Areas.UserManagement.AddUser.Proflies
{
    public class AddUserRequestProfile : Profile
    {
        public AddUserRequestProfile()
        {
            CreateMap<AddUserRequest, User>();
        }
    }
}
