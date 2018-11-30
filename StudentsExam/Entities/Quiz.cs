using StudentsExam.FileUtils;
using StudentsExam.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace StudentsExam.Entities
{
	public class Quiz
	{
		private static readonly Lazy<List<Question>> Questions = new Lazy<List<Question>>(() =>
			JsonUtils.LoadJsonFile(ConfigurationManager.AppSettings["QuizQuestions"])["Questions"].ToObject<List<Question>>());

		private readonly string nl = Environment.NewLine;

		public event EventHandler QuizFinisHandler;

		public void QuizFinish(List<UserAnswer> answers)
		{
			QuizFinisHandler?.Invoke(this, new CustomArgs(answers));
		}

		public List<UserAnswer> StartQuiz(IUser user)
		{
			Console.WriteLine($"{nl}   Please answer following questions using numbers from 1 to 4 ONLY !");
			List<UserAnswer> answers = new List<UserAnswer>();

			foreach (var question in Questions.Value)
			{
				Console.WriteLine($"{nl} * {question.QuestionText}");

				foreach (var answer in question.PossibleAnswers)
				{
					Console.WriteLine($" - {answer.Number}. {answer.Text} {nl}");
				}

				Console.WriteLine("Enter your choice...");

				if (int.TryParse(Console.ReadLine(), out int answerNumber))
				{
					answers.Add(new UserAnswer(user, question, answerNumber));
				}
			}

			return answers;
		}
	}
}
