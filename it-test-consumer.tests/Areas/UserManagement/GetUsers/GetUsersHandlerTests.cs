using AutoFixture;
using AutoMapper;
using FluentAssertions;
using it_test_consumer.Areas.UserManagement.GetUsers;
using it_test_consumer.Areas.UserManagement.GetUsers.Profiles;
using it_test_consumer.Data;
using it_test_consumer.Data.Models;
using it_test_consumer.Data.Repositories;
using Moq;
using Moq.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace it_test_consumer.tests.Areas.UserManagement.GetUsers
{
    public class GetUsersHandlerTests
    {
        private readonly GetUsersHandler _handler;

        private const int MaxNumberOfUsers = 100;

        public GetUsersHandlerTests()
        {
            var dbContextMock = new Mock<ItTestDbContext>();
            dbContextMock.Setup(x => x.Set<User>()).ReturnsDbSet(GenerateUsers());

            var fakeUserRepository = new UsersRepository(dbContextMock.Object);
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>()).CreateMapper();

            _handler = new GetUsersHandler(fakeUserRepository, mapper);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public async Task Handle_ShoudReturnCorrectNumberOfElements_WhenCorrectPageSize(int pageSize)
        {
            // Arrange
            var request = new GetUsersRequest { PageSize = pageSize };

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Count().Should().Be(pageSize);
        }

        [Theory]
        [InlineData(101)]
        [InlineData(200)]
        public async Task Handle_ShoudReturnMaxNumberOfElements_WhenLargePageSize(int pageSize)
        {
            // Arrange
            var request = new GetUsersRequest { PageSize = pageSize };

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Count().Should().Be(MaxNumberOfUsers);
        }

        private IEnumerable<User> GenerateUsers()
        {
            return new Fixture().CreateMany<User>(MaxNumberOfUsers);
        }
    }
}
