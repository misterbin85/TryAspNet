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
                    return default(IUser);
            }
        }
    }
}