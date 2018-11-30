using System.Linq;

namespace StudentsExam.Entities
{
	public class UserAnswer
	{
		#region Properties

		public string UserName;

		public string QuestionText { get; private set; }

		public string AnswerText { get; private set; }

		public bool IsCorrect { get; private set; }

		#endregion Properties

		#region Constructor

		public UserAnswer(IUser user, Question question, int answerNumber)
		{
			UserName = user.Name;
			QuestionText = question.QuestionText;
			IsCorrect = question.PossibleAnswers.First(variant => variant.Number.Equals(answerNumber)).IsCorrect;
			AnswerText = question.PossibleAnswers.First(variant => variant.Number.Equals(answerNumber)).Text;
		}

		#endregion Constructor
	}
}