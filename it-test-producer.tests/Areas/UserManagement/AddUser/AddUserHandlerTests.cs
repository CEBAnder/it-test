using AutoMapper;
using it_test_producer.Areas.UserManagement.AddUser;
using it_test_shared_contracts.Models;
using MassTransit;
using Moq;
using Serilog.Core;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace it_test_producer.tests.Areas.UserManagement.AddUser
{
    public class AddUserHandlerTests
    {


        [Fact]
        public async Task Handle_ShouldPublishMessage()
        {
            // Arrange
            var userToPublish = new User();
            var mapperMock = new Mock<IMapper>();
            mapperMock
                .Setup(x => x.Map<User>(It.IsAny<AddUserRequest>()))
                .Returns(userToPublish);
            var publishEndpointMock = new Mock<IPublishEndpoint>();
            var hanlder = new AddUserHandler(mapperMock.Object, publishEndpointMock.Object, Logger.None);

            // Act
            await hanlder.Handle(new AddUserRequest(), CancellationToken.None);

            // Assert
            publishEndpointMock.Verify(publishEndpointMock => publishEndpointMock.Publish(userToPublish, CancellationToken.None), Times.Once);
        }
    }
}
