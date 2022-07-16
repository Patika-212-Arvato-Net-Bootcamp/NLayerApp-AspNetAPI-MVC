using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IRedisService
    {
        public void Connect();
        public IDatabase GetDb(int db);
      
    }
}
