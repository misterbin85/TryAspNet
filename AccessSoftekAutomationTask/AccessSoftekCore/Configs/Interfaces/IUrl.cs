using System.Collections.Generic;
using Config.Net;

namespace AccessSoftekCore.Configs.Interfaces
{
    public interface IUrl
    {
        [Option(Alias = "authority")]
        string Authority { get; }

        IEnumerable<IPath> Paths { get; }
    }
}