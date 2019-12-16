using Config.Net;

namespace AccessSoftekCore.Configs.Interfaces
{
    public interface IPath
    {
        [Option(Alias = "name")]
        string Name { get; }

        [Option(Alias = "path")]
        string Path { get; }
    }
}