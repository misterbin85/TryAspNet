using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomAuthenticationMVC.Models
{
	public class Question
	{
		public int Id { get; set; }

		[Display(Name = "Question:")]
		public string QuestionText { get; set; }

		public virtual ICollection<Answer> PossibleAnswers { get; set; }
	}
}