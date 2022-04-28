using AutoFixture;
using FluentAssertions;
using it_test_consumer.Areas.UserManagement.BindOrgUser;
using it_test_consumer.Data.Exceptions;
using it_test_consumer.Data.Models;
using it_test_consumer.Infrastructure.Exceptions;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static it_test_consumer.Data.Helpers.IRepository;

namespace it_test_consumer.tests.Areas.UserManagement.BindOrgUser
{
    public class BindOrgUserHandlerTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public async Task Handle_ShouldBeOk_WhenCorrectIds()
        {
            // Arrange
            var request = _fixture.Create<BindOrgUserRequest>();
            var userToReturn = new User { Id = request.UserId, OrgId = null };

            var userRepo = new Mock<IRepository<User>>();
            userRepo.Setup(x => x.FindOne(x => x.Id == request.UserId)).ReturnsAsync(userToReturn);

            var orgRepo = new Mock<IRepository<Organisation>>();
            orgRepo.Setup(x => x.FindOne(x => x.Id == request.OrgId)).ReturnsAsync(new Organisation());

            var handler = new BindOrgUserHandler(userRepo.Object, orgRepo.Object);

            // Act
            await handler.Handle(request, CancellationToken.None);

            // Assert
            userRepo.Verify(x => x.Update(userToReturn), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenUserNotFound()
        {
            // Arrange
            var request = _fixture.Create<BindOrgUserRequest>();

            var userRepo = new Mock<IRepository<User>>();
            userRepo.Setup(x => x.FindOne(x => x.Id == request.UserId)).ThrowsAsync(new EntityNotFoundException<User>());

            var orgRepo = new Mock<IRepository<Organisation>>();
            orgRepo.Setup(x => x.FindOne(x => x.Id == request.OrgId)).ReturnsAsync(new Organisation());

            var handler = new BindOrgUserHandler(userRepo.Object, orgRepo.Object);

            // Act
            // Assert
            var result = await Assert.ThrowsAsync<NotFoundException<User>>(() => handler.Handle(request, CancellationToken.None));
            result.Message.Should().Be($"User with Id = {request.UserId} not found!");
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenOrganisationNotFound()
        {
            // Arrange
            var request = _fixture.Create<BindOrgUserRequest>();

            var userRepo = new Mock<IRepository<User>>();
            userRepo.Setup(x => x.FindOne(x => x.Id == request.UserId)).ReturnsAsync(new User());

            var orgRepo = new Mock<IRepository<Organisation>>();
            orgRepo.Setup(x => x.FindOne(x => x.Id == request.OrgId)).ThrowsAsync(new EntityNotFoundException<Organisation>());

            var handler = new BindOrgUserHandler(userRepo.Object, orgRepo.Object);

            // Act
            // Assert
            var result = await Assert.ThrowsAsync<NotFoundException<Organisation>>(() => handler.Handle(request, CancellationToken.None));
            result.Message.Should().Be($"Organisation with Id = {request.OrgId} not found!");
        }
    }
}
