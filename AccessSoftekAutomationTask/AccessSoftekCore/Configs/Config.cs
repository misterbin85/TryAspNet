using System;
using AccessSoftekCore.Configs.Interfaces;
using AccessSoftekCore.Utils;
using Config.Net;

namespace AccessSoftekCore.Configs
{
    public sealed class Config
    {
        public static IConfig Properties { get; private set; }

        static Config()
        {
            Properties = Conf.Value;
        }

        private static readonly Lazy<IConfig> Conf = new Lazy<IConfig>(() =>
        {
            var exeDir = DirectoryUtils.Executables();
            IConfig config = new ConfigurationBuilder<IConfig>()
                .UseJsonFile($"{exeDir}\\config.json")
                .Build();
            return config;
        });
    }
}