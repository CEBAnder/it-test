using AutoFixture;
using AutoMapper;
using FluentAssertions;
using it_test_consumer.Areas.UserManagement.GetUsers;
using it_test_consumer.Areas.UserManagement.GetUsers.Profiles;
using it_test_consumer.Data;
using it_test_consumer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static it_test_consumer.Data.Helpers.IRepository;

namespace it_test_consumer.tests.Areas.UserManagement.GetUsers
{
    public class GetUsersHandlerTests
    {        
        private readonly GetUsersHandler _handler;

        public GetUsersHandlerTests()
        {
            var usersRepoMock = new Mock<IRepository<User>>();

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>()).CreateMapper();
            _handler = new GetUsersHandler(usersRepoMock.Object, mapper);
        }

        [Theory]
        [InlineData(10)]
        public async Task Handle_ShoudReturnCorrectNumberOfElements_WhenCorrectPageSize(int pageSize)
        {
            // Arrange
            var request = new GetUsersRequest { PageSize = pageSize, PageNumber = 1 };

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Count().Should().Be(pageSize);
        }

        private IQueryable<User> GenerateUsers()
        {
            var users = new Fixture().CreateMany<User>(100);

            return users.AsQueryable();
        }
    }
}
