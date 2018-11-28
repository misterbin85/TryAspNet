using System;
using System.Configuration;
using System.Linq;
using StudentsExam.Entities;
using StudentsExam.Factories;

namespace StudentsExam
{
    public class AuthenticationHelper
    {
        private readonly string _nl = Environment.NewLine;

        public IUser Authenticate()
        {
            var allowedUsers = new Users(ConfigurationManager.AppSettings["LoginUsers"]);

            IUser user = this.SelectUserType();

            user = this.GetCredentials(user);
            IUser authUser;
            if (user.GetType() == typeof(Student))
            {
                authUser = allowedUsers.Students.FirstOrDefault(student => student.Name.Equals(user.Name) && student.Email.Equals(user.Email));
            }
            else
            {
                authUser = allowedUsers.Teachers.FirstOrDefault(teacher => teacher.Name.Equals(user.Name) && teacher.Email.Equals(user.Email));
            }

            if (authUser == null)
            {
                Console.WriteLine("Selected User wasn't found. Please try again");
                return Authenticate();
            }

            return authUser;
        }

        private IUser SelectUserType()
        {
            Console.WriteLine($"Please select:{_nl} 1 - you are a Teacher {_nl} 2 - you are a Student{_nl} And hit Enter...");
            string userInput = Console.ReadLine();
            bool res = int.TryParse(userInput, out int choice);

            if (!res || choice > 2)
            {
                Console.WriteLine("Please select only mentioned numbers. Trying again:");
                return SelectUserType();
            }

            return UsersFactory.GetUser(choice);
        }

        private IUser GetCredentials(IUser user)
        {
            Console.WriteLine($"You're trying to login as a:'{user.GetType().Name}'.");
            Console.WriteLine("Please enter your Name:");
            user.Name = Console.ReadLine();
            Console.WriteLine("Please enter your Email:");
            user.Email = Console.ReadLine();

            return user;
        }
    }
}