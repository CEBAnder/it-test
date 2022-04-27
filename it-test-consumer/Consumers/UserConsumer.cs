﻿using AutoMapper;
using it_test_consumer.Data;
using MassTransit;
using System.Text.Json;

namespace it_test_consumer.Consumers
{
    public class UserConsumer : IConsumer<it_test_shared_contracts.Models.User>
    {
        private readonly IMapper _mapper;
        private readonly ItTestDbContext _dbContext;
        private readonly Serilog.ILogger _logger;

        public UserConsumer(IMapper mapper, ItTestDbContext dbContext, Serilog.ILogger logger)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<it_test_shared_contracts.Models.User> context)
        {
            var user = context.Message;
            _logger.Information($"Got user {JsonSerializer.Serialize(user)}");

            var userForDb = _mapper.Map<Data.Models.User>(user);
            await _dbContext.Users.AddAsync(userForDb);
            await _dbContext.SaveChangesAsync();

            _logger.Information("Added user to database");
        }
    }
}
