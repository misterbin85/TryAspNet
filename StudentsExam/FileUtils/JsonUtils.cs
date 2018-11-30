using Newtonsoft.Json.Linq;
using System.IO;
using System.Reflection;

namespace StudentsExam.FileUtils
{
	public sealed class JsonUtils
	{
		private static readonly string ExeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)?.Replace("file:\\", string.Empty);

		public static JObject LoadJsonFile(string fileName)
		{
			return JObject.Parse(File.ReadAllText($@"{ExeDir}\JSONs\{fileName}.json"));
		}

		public static void SaveJsonToFile(string jsonString)
		{
			var fileName = "Test"; // temporary hardcoded for testing
			File.WriteAllText($@"{ExeDir}\JSONs\{fileName}.json", jsonString);
		}
	}
}
