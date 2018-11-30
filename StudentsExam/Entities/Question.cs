using System.Collections.Generic;

namespace StudentsExam.Entities
{
	public class Question
	{
		public int Id { get; set; }

		public string QuestionText { get; set; }

		public IList<AnswerVariant> PossibleAnswers { get; set; }
	}
}