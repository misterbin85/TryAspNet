using Newtonsoft.Json.Linq;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace StudentsExam.FileUtils
{
    public sealed class JsonUtils
    {
        private static readonly string ExeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)?.Replace("file:\\", string.Empty);
        private static readonly string SaveResultsDirectory = $@"{ExeDir}\JSONs\QuizResults";

        public static JObject LoadJsonFile(string fileName)
        {
            return JObject.Parse(File.ReadAllText($@"{ExeDir}\JSONs\{fileName}.json"));
        }

        public static void SaveJsonToFile(string fileName, object jsonObject)
        {
            var jsonString = JsonConvert.SerializeObject(jsonObject);
            if (!Directory.Exists(SaveResultsDirectory))
            {
                Directory.CreateDirectory(SaveResultsDirectory);
            }

            File.WriteAllText($@"{SaveResultsDirectory}\{ fileName}_result.json", jsonString);
        }
    }
}