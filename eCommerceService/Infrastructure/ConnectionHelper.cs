﻿using Microsoft.IdentityModel.Protocols;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Infrastructure
{
    public class ConnectionHelper
    {
        static ConnectionHelper()
        {
            ConnectionHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("127.0.0.1:6379");
            });
        }
        private static Lazy<ConnectionMultiplexer> lazyConnection;
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
