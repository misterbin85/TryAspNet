using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using StudentsExam.FileUtils;

namespace StudentsExam.Entities
{
    public class Users
    {
        public Users(string fileName)
        {
            this.LoadLoadUsers(JsonUtils.LoadJsonFile(fileName));
        }

        private void LoadLoadUsers(JObject o)
        {
            this.Teachers = o["Users"].First["Teachers"].ToObject<IList<Teacher>>();
            this.Students = o["Users"].Last["Students"].ToObject<IList<Student>>();
        }

        public IList<Student> Students { get; set; }

        public IList<Teacher> Teachers { get; set; }
    }
}