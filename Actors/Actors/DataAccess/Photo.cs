using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actors.DataAccess
{
	public class Photo
	{
		public int Id { get; set; }

		public string Path { get; set; }

		public int ActorId { get; set; }

		public bool IsMain { get; set; }

		[Required]
		[ForeignKey(nameof(ActorId))]
		public Actor Actor { get; set; }
	}
}