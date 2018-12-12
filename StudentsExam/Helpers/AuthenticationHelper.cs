using StudentsExam.Entities;
using StudentsExam.Factories;
using System;
using System.Configuration;
using System.Linq;

namespace StudentsExam.Helpers
{
	public class AuthenticationHelper
	{
		private delegate void ClearScreen();

		private delegate string ReadInput();

		#region Fields

		private readonly Users _allowedUsers;

		private readonly string _nl = Environment.NewLine;

		private readonly ReadInput _readInput = Console.ReadLine;

		private readonly ClearScreen _clear = Console.Clear;

		#endregion Fields

		#region Methods

		public AuthenticationHelper()
		{
			_allowedUsers = new Users(ConfigurationManager.AppSettings["LoginUsers"]);
		}

		public IUser Authenticate()
		{
			IUser user = SelectUserType();
			user = ObtainCredentials(user);

			if (user.GetType() == typeof(Student))
			{
				user = _allowedUsers.Students.FirstOrDefault(student => student.Name.ToLower().Equals(user.Name) && student.Email.ToLower().Equals(user.Email));
			}
			else
			{
				user = _allowedUsers.Teachers.FirstOrDefault(teacher => teacher.Name.ToLower().Equals(user.Name) && teacher.Email.ToLower().Equals(user.Email));
			}

			if (user == null)
			{
				_clear();
				Console.WriteLine("Selected User wasn't found. Please try again");
				return Authenticate();
			}

			return user;
		}

		private IUser SelectUserType()
		{
			var availableUserTypes = UserStrategy.AvailableUserTypes();

			Console.WriteLine($"Available options are:");

			foreach (var aKey in availableUserTypes.Keys)
			{
				Console.WriteLine($"{aKey} - {availableUserTypes[aKey].Name}");
			}
			Console.WriteLine($"Please select your choice:{_nl}  And hit Enter...");

			string userInput = _readInput();

			bool res = int.TryParse(userInput, out int choice);

			if (!res || choice >= availableUserTypes.Count)
			{
				_clear();
				Console.WriteLine("Please select only mentioned numbers. Trying again:");
				return SelectUserType();
			}

			_clear();
			return UserStrategy.RetrieveUser(choice);
		}

		private IUser ObtainCredentials(IUser user)
		{
			Console.WriteLine($"You're trying to login as a:'{user.GetType().Name}'.");
			Console.WriteLine("Please enter your Name:");
			user.Name = _readInput()?.ToLower();
			Console.WriteLine("Please enter your Email:");
			user.Email = _readInput()?.ToLower();
			_clear();

			return user;
		}

		#endregion Methods
	}
}