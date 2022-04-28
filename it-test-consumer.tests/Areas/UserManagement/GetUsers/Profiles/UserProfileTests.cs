using AutoFixture;
using AutoMapper;
using FluentAssertions;
using it_test_consumer.Areas.UserManagement.GetUsers;
using it_test_consumer.Areas.UserManagement.GetUsers.Profiles;
using it_test_consumer.Data.Models;
using Xunit;

namespace it_test_consumer.tests.Areas.UserManagement.GetUsers.Profiles
{
    public class UserProfileTests
    {
        private readonly IMapper _mapper;

        public UserProfileTests()
        {
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>()).CreateMapper();
        }

        [Fact]
        public void Map_ShouldReturnCorrectType_WhenValidInput()
        {
            // Arrange
            var user = new Fixture().Create<User>();
            var expected = new GetUsersResponse
            {
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                OrgName = user.Organisation?.Name
            };

            // Act
            var result = _mapper.Map<GetUsersResponse>(user);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
