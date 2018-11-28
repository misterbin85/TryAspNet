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
					return new Student();

				case 2:
					return new Teacher();

				default:
					return default(IUser);
			}
		}
	}
}
