using System.Collections.Generic;

namespace Actors.Models
{
	public class ActorViewModel
	{
		public Actor Actor { get; set; }
		public List<Photo> Photos { get; set; }

		public ActorViewModel(Actor actor, List<Photo> photos)
		{
			Actor = actor;
			Photos = photos;
		}
	}
}