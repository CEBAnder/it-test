using AutoMapper;
using it_test_consumer.Data.Models;
using MassTransit;
using System.Text.Json;
using static it_test_consumer.Data.Helpers.IRepository;

namespace it_test_consumer.Consumers
{
    public class UserConsumer : IConsumer<it_test_shared_contracts.Models.User>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _usersRepository;
        private readonly Serilog.ILogger _logger;

        public UserConsumer(IMapper mapper, IRepository<User> usersRepository, Serilog.ILogger logger)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<it_test_shared_contracts.Models.User> context)
        {
            var user = context.Message;
            _logger.Information($"Got user {JsonSerializer.Serialize(user)}");

            var userForDb = _mapper.Map<Data.Models.User>(user);
            await _usersRepository.Add(userForDb);;

            _logger.Information("Added user to database");
        }
    }
}
