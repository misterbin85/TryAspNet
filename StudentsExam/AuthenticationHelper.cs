using System;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using StudentsExam.Entities;
using StudentsExam.Factories;

namespace StudentsExam
{
	public class AuthenticationHelper
	{
		private IUser SelectUserType()
		{
			Console.WriteLine($"Please select:{Environment.NewLine} 1 - you are a Teacher {Environment.NewLine} 2 - you are a Student");

			Int32.TryParse(Console.ReadLine(), out int choice);
			if (choice == 0 || choice > 2)
			{
				Console.WriteLine("Please select only mentioned numbers. Trying again:");
				SelectUserType();
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

		public IUser Authenticate()
		{
			var allowedUsers = new Users(ConfigurationManager.AppSettings["LoginUsers"]);

			IUser user = this.SelectUserType();

			user = this.GetCredentials(user);
			IUser authUser;
			if (user.GetType() == typeof(Student))
			{
				authUser = allowedUsers.Students.Single(student => student.Name.Equals(user.Name) && student.Email.Equals(user.Email));
			}
			else
			{
				authUser = allowedUsers.Teachers.Single(teacher => teacher.Name.Equals(user.Name) && teacher.Email.Equals(user.Email));
			}

			return authUser;
		}
	}
}