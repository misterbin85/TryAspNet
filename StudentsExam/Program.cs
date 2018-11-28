namespace StudentsExam
{
	public class Program
	{
		private static void Main(string[] args)
		{
			var authHelper = new AuthenticationHelper();
			authHelper.Authenticate();
		}
	}
}
