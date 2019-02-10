namespace Actors.Models
{
    public class Actor
    {
        public int ActorId { get; set; }

        public string FullName { get; set; }

        public Gender ActorGender { get; set; }

        public string Photo { get; set; }

        public enum Gender
        {
            male,
            female
        }
    }
}