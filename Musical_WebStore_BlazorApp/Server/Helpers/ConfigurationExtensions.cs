﻿using Microsoft.Extensions.Configuration;

namespace Musical_WebStore_BlazorApp.Server.Helpers
{
    public static class ConfigurationExtensions
    {
        public static DatabaseType GetDatabaseType(this IConfiguration configuration) 
            => (DatabaseType)configuration.GetValue<byte>("DatabaseType");

        public static long GetAdminGroupId(this IConfiguration configuration) 
            => configuration.GetValue<long>("TelegramAdminGroupId");
    }
}
