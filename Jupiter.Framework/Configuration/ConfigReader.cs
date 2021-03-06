﻿using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Jupiter.Framework.Configuration
{
    public class ConfigReader
    {
        private const string SettingsFile = "appSettings.json";

        public static readonly string BaseDirectory = AppContext.BaseDirectory
            .Substring(0, AppContext.BaseDirectory.IndexOf("bin", StringComparison.Ordinal));

        public static void SetConfig()
        {
            Config.Instance = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(SettingsFile)
                .Build()
                .Get<Config>();
        }
    }
}
