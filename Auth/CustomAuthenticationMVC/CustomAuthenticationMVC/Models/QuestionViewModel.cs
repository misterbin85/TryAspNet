using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CustomAuthenticationMVC.DataAccess;

namespace CustomAuthenticationMVC.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Question:")]
        public string QuestionText { get; set; }

        [Display(GroupName = "Possible answers")]
        public ICollection<AnswerViewModel> PossibleAnswers { get; set; }


        public QuestionViewModel(Question question)
        {
            this.Id = question.Id;
            this.QuestionText = question.QuestionText;
            this.PossibleAnswers = question.PossibleAnswers
                .Select(a =>
                    new AnswerViewModel() { Id = a.Id, Text = a.Text, IsCorrect = a.IsCorrect }).ToList();
        }


    }
}