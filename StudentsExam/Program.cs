using StudentsExam.Entities;

namespace StudentsExam
{
    public class Program
    {
        private static void Main(string[] args)
        {
            IUser user = new AuthenticationHelper().Authenticate();
        }
    }
}