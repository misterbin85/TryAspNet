using Newtonsoft.Json;
using StudentsExam.Entities;
using StudentsExam.FileUtils;
using System;

namespace StudentsExam.Helpers
{
	public class ResultsSaver
	{
		public ResultsSaver(Quiz quiz)
		{
			quiz.QuizFinisHandler += SaveResults;
		}

		private void SaveResults(object sender, EventArgs e)
		{
			var jsonString = JsonConvert.SerializeObject(((CustomArgs)e).Answers);

			JsonUtils.SaveJsonToFile(jsonString);
		}
	}
}
