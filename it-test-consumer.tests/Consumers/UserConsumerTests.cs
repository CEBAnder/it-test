using AutoMapper;
using it_test_consumer.Consumers;
using it_test_consumer.Data.Models;
using MassTransit;
using Moq;
using Serilog.Core;
using System.Threading.Tasks;
using Xunit;
using static it_test_consumer.Data.Helpers.IRepository;

namespace it_test_consumer.tests.Consumers
{
    public class UserConsumerTests
    {
        [Fact]
        public async Task Consume_ShouldBeOk_WhenCorrectData()
        {
            // Arrange
            var userToAdd = new User();

            var mapperMock = new Mock<IMapper>();
            mapperMock
                .Setup(x => x.Map<User>(It.IsAny<it_test_shared_contracts.Models.User>()))
                .Returns(userToAdd);

            var repoMock = new Mock<IRepository<User>>();

            var consumer = new UserConsumer(mapperMock.Object, repoMock.Object, Logger.None);

            var consumeContext = new Mock<ConsumeContext<it_test_shared_contracts.Models.User>>();

            // Act
            await consumer.Consume(consumeContext.Object);

            // Assert
            repoMock.Verify(x => x.Add(userToAdd), Times.Once);
        }
    }
}
