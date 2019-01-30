using System.Collections.Generic;

namespace CustomAuthenticationMVC.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string QuestionText { get; set; }

        public virtual ICollection<Answer> PossibleAnswers { get; set; }
    }
}