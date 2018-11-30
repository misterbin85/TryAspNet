using Newtonsoft.Json;
using StudentsExam.Entities;
using StudentsExam.FileUtils;
using System;
using System.Linq;

namespace StudentsExam.Helpers
{
	public class QuizResultsSaver
	{
		private readonly Quiz quiz;

		public QuizResultsSaver(Quiz quiz)
		{
			this.quiz = quiz;
		}

		public void SubscribeToQuiz()
		{
			quiz.QuizFinisHandler += SaveResults;
		}

		private void SaveResults(object sender, EventArgs e)
		{
			var user = ((CustomArgs)e).Answers.First().UserName;

			var resultObject = new
			{
				UserName = user,
				Answers = ((CustomArgs)e).Answers.Select(answer => new
				{
					QuestionText = answer.QuestionText,
					AnswerText = answer.AnswerText,
					IsCorrect = answer.IsCorrect
				}).ToList()
			};

			var jsonString = JsonConvert.SerializeObject(resultObject);

			JsonUtils.SaveJsonToFile(user, jsonString);
		}
	}
}
