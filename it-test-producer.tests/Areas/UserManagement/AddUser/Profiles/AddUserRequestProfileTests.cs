using AutoFixture;
using AutoMapper;
using FluentAssertions;
using it_test_producer.Areas.UserManagement.AddUser;
using it_test_producer.Areas.UserManagement.AddUser.Proflies;
using it_test_shared_contracts.Models;
using Xunit;

namespace it_test_producer.tests.Areas.UserManagement.AddUser.Profiles
{
    public class AddUserRequestProfileTests
    {
        private readonly IMapper _mapper;

        public AddUserRequestProfileTests()
        {
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<AddUserRequestProfile>()).CreateMapper();
        }

        [Fact]
        public void Map_ShouldReturnCorrectType_WhenValidInput()
        {
            // Arrange
            var request = new Fixture().Create<AddUserRequest>();
            var expected = new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Patronymic = request.Patronymic,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email
            };

            // Act
            var result = _mapper.Map<User>(request);

            // Asser
            result.Should().BeEquivalentTo(expected);
        }
    }
}
