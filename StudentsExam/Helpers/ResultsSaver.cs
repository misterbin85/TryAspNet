using Newtonsoft.Json;
using StudentsExam.Entities;
using StudentsExam.FileUtils;
using System;
using System.Linq;

namespace StudentsExam.Helpers
{
    public class QuizResultsSaver
    {
        private readonly Quiz _quiz;

        #region Constructor

        public QuizResultsSaver(Quiz quiz)
        {
            this._quiz = quiz;
        }

        #endregion Constructor

        #region Methods

        public void SubscribeToQuiz()
        {
            _quiz.QuizFinisHandler += SaveResults;
        }

        private void SaveResults(object sender, EventArgs e)
        {
            var answers = ((CustomArgs)e).Answers;
            var user = answers.First().UserName;

            var resultObject = new
            {
                UserName = user,
                Score = answers.Count(a => a.IsCorrect),
                Answers = answers.Select(answer => new
                {
                    QuestionText = answer.QuestionText,
                    AnswerText = answer.AnswerText,
                    IsCorrect = answer.IsCorrect
                }).ToList()
            };

            JsonUtils.SaveJsonToFile(user, resultObject);
        }

        #endregion Methods
    }
}