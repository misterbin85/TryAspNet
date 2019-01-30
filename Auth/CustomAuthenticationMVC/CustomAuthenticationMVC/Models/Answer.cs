using System.ComponentModel.DataAnnotations.Schema;

namespace CustomAuthenticationMVC.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }

        [ForeignKey(nameof(QuestionId))]
        public Question Question { get; set; }
    }
}