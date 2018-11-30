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
				var quiz = new Quiz(user);
				quiz.StartQuiz();
			}
		}
	}
}