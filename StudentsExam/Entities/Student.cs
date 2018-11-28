namespace StudentsExam.Entities
{
	public class Student : IUser
	{
		public string Name { get; set; }

		public string Email { get; set; }

		public int NumberOfCorrectAnswers { get; set; }
	}
}
