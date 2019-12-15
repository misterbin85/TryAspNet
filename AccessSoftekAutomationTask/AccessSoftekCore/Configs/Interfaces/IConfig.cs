using Config.Net;

namespace AccessSoftekCore.Configs.Interfaces
{
    public interface IConfig
    {
        [Option(Alias = "browser")]
        string Browser { get; set; }

        [Option(Alias = "environment")]
        string Environment { get; set; }

        [Option(Alias = "main-app")]
        IApplication MainApplication { get; }
    }
}