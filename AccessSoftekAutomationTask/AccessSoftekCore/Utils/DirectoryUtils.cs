using System.IO;
using System.Reflection;

namespace AccessSoftekCore.Utils
{
    internal class DirectoryUtils
    {
        public static string Executables()
        {
            var exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (exeDir != null && exeDir.Contains("assembly"))
            {
                exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)?.Replace("file:\\", string.Empty);
            }

            return exeDir;
        }
    }
}