using AutoFixture;
using AutoMapper;
using FluentAssertions;
using it_test_consumer.Consumers.Profiles;
using Xunit;

namespace it_test_consumer.tests.Consumers.Profiles
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
            var user = new Fixture().Create<it_test_shared_contracts.Models.User>();
            var expected = new Data.Models.User
            {
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                OrgId = null,
                Organisation = null
            };

            // Act
            var result = _mapper.Map<Data.Models.User>(user);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
