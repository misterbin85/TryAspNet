namespace Actors.Models
{
	public class Photo
	{
		public int PhotoId { get; set; }

		public string PhotoPath { get; set; }

		public int ActorId { get; set; }

		public bool IsMain { get; set; }
	}
}