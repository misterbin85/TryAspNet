using StudentsExam.FileUtils;
using StudentsExam.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace StudentsExam.Entities
{
    public class Quiz
    {
        private static readonly Lazy<List<Question>> Questions = new Lazy<List<Question>>(() =>
            JsonUtils.LoadJsonFile(ConfigurationManager.AppSettings["QuizQuestions"])["Questions"].ToObject<List<Question>>());

        private readonly string nl = Environment.NewLine;

        public readonly IUser User;

        public event EventHandler QuizFinisHandler;

        #region Constructor

        public Quiz(IUser user)
        {
            User = user;
            var resultsSaver = new QuizResultsSaver(this);
            resultsSaver.SubscribeToQuiz();
        }

        #endregion Constructor

        #region Methods

        public void StartQuiz()
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

                Console.WriteLine($"{nl} Enter your choice...");

                if (int.TryParse(Console.ReadLine(), out int answerNumber))
                {
                    answers.Add(new UserAnswer(User, question, answerNumber));
                    Console.Clear();
                }
            }

            QuizFinish(answers);
        }

        private void QuizFinish(List<UserAnswer> answers)
        {
            Console.WriteLine($"You have {answers.Count(a => a.IsCorrect)} correct answers. Creating results file.{Environment.NewLine} Press any button for exit the quiz");
            Console.ReadLine();
            QuizFinisHandler?.Invoke(this, new CustomArgs(answers));
        }

        #endregion Methods
    }
}