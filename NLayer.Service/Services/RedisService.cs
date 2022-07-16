using Microsoft.Extensions.Configuration;
using NLayer.Core.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class RedisService:IRedisService
    {
        private readonly string _redisHost;

        private readonly string _redisPort;
        private ConnectionMultiplexer _redis;

        public IDatabase db { get; set; }

        public RedisService(IConfiguration configuration)
        {
            _redisHost = configuration["Redis:Host"];

            _redisPort = configuration["Redis:Port"];
        }

        public void Connect()
        {
            var configString = $"{_redisHost}:{_redisPort}";

            _redis = ConnectionMultiplexer.Connect(configString);
        }

        public IDatabase GetDb(int db)
        {
            return _redis.GetDatabase(db);
        }
    }
}
