using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Infrastructure
{
    public class SystemConfig
    {
        public string Name { get; set; }
        public string Admin { get; set; }
        public string DbConnectionString { get; set; }
        public string RedisConnectionString { get; set; }
        public int CacheType { get; set; }
    }
}
