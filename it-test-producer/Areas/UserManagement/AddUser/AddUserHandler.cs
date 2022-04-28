using AutoMapper;
using it_test_shared_contracts.Models;
using MassTransit;
using MediatR;
using System.Text.Json;

namespace it_test_producer.Areas.UserManagement.AddUser
{
    public class AddUserHandler : IRequestHandler<AddUserRequest>
    {
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly Serilog.ILogger _logger;

        public AddUserHandler(IMapper mapper, IPublishEndpoint publishEndpoint, Serilog.ILogger logger)
        {
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        public async Task<Unit> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            await _publishEndpoint.Publish(user, cancellationToken);

            _logger.Information($"Produced user: {JsonSerializer.Serialize(user)} to RabbitMq");

            return Unit.Value;
        }
    }
}
