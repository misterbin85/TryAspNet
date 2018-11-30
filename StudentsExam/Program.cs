using StudentsExam.Entities;
using StudentsExam.Helpers;

namespace StudentsExam
{
	public class Program
	{
		private static void Main(string[] args)
		{
			IUser user = new AuthenticationHelper().Authenticate();
			if (user.GetType() == typeof(Student))
			{
				var quiz = new Quiz();
				var resultsSaver = new ResultsSaver(quiz);
				var answers = quiz.StartQuiz(user);
				quiz.QuizFinish(answers);
			}
		}
	}
}