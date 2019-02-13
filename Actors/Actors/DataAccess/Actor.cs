using System.Collections.Generic;

namespace Actors.DataAccess
{
	public class Actor
	{
		public int Id { get; set; }

		public string FullName { get; set; }

		public string Gender { get; set; }

		public string FullInfo { get; set; }

		public ICollection<Photo> Photos { get; set; }
	}
}