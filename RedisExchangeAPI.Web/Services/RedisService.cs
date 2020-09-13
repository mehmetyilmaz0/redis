using System;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace RedisExchangeAPI.Web.Services
{
    public class RedisService
    {
        private readonly string _redisHost;

        private readonly string _redisPort;

        private ConnectionMultiplexer _redis; // bu class uzerinden redis server uzerinden haberlesecegiz.

        public IDatabase db { get; set; } 

        public RedisService(IConfiguration configuration)
        {
            _redisHost = configuration["Redis:Host"]; // appsettings.json icindeki "Redis" olarak tanimladigimiz "Host" bilgisini aldik
            _redisPort = configuration["Redis:Port"]; // appsettings.json icindeki "Redis" olarak tanimladigimiz "Port" bilgisini aldik
        }


        // uygulamam ilk ayaga kalktiginda redis server ile haberlesmesi gerekiyor
        public void Connect()
        {
            var configString = $"{_redisHost}:{_redisPort}";

            _redis = ConnectionMultiplexer.Connect(configString); // suan host ve port bilgisi ile redis server ile haberlestik.
        }

        // redis desktop manager uzerinde gordugumuz 16 adet veritabani vardi. bu veritabanlari arasindan istedigimiz veritabani ile calismak icin bir metod yazalim.
        public IDatabase GetDb(int db)
        {
            return _redis.GetDatabase(db); 
        }

    }
}
