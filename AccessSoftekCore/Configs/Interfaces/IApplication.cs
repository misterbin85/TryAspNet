using Config.Net;

namespace AccessSoftekCore.Configs.Interfaces
{
    public interface IApplication
    {
        [Option(Alias = "name")]
        string Name { get; set; }

        [Option(Alias = "url")]
        IUrl Url { get; }
    }
}