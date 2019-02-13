using System.Collections.Generic;

namespace Actors.Models
{
	public class ActorViewModel
	{
		public ActorModel Actor { get; set; }
		public List<PhotoModel> Photos { get; set; }

		public ActorViewModel(ActorModel actor, List<PhotoModel> photos)
		{
			Actor = actor;
			Photos = photos;
		}
	}
}