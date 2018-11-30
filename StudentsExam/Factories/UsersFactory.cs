using System;
using StudentsExam.Entities;

namespace StudentsExam.Factories
{
	public class UsersFactory
	{
		public static IUser GetUser(int choice)
		{
			switch (choice)
			{
				case 1:
					return new Teacher();

				case 2:
					return new Student();

				default:
					Console.WriteLine($"{typeof(UsersFactory).Name} returning default value");
					return default(IUser);
			}
		}
	}
}