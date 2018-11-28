using Newtonsoft.Json.Linq;
using System.IO;
using System.Reflection;

namespace StudentsExam.FileUtils
{
	public sealed class JsonUtils
	{
		public static JObject LoadJsonFile(string fileName)
		{
			var exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)?.Replace("file:\\", string.Empty);

			return JObject.Parse(File.ReadAllText($@"{exeDir}\JSONs\{fileName}.json"));
		}
	}
}
