using Actors.Models;
using Bogus;
using System.Collections.Generic;
using System.Linq;

namespace Actors.Repositories
{
	public class ActorsRepository
	{
		public static List<ActorViewModel> GetAllActors()
		{
			List<ActorViewModel> actorViewModels = new List<ActorViewModel>();

			// fake data before DB implementation
			var fakeActors = new Faker<Actor>()
				.RuleFor(a => a.ActorId, f => f.UniqueIndex)
				.RuleFor(a => a.FullName, f => f.Internet.UserName())
				.RuleFor(a => a.ActorGender, f => f.PickRandom(new[] { "male", "female" }))
				.Generate(5).ToList();

			var fakePhotos = new Faker<Photo>()
				.RuleFor(p => p.ActorId, f => f.PickRandom(new List<int>(fakeActors.Select(a => a.ActorId))))
				.RuleFor(p => p.PhotoPath, f => f.Lorem.Word() + ".png")
				.RuleFor(p => p.PhotoId, f => f.UniqueIndex)
				.RuleFor(p => p.IsMain, f => f.PickRandom(new[] { true, false }))
				.Generate(50).ToList();

			foreach (var actor in fakeActors)
			{
				var curActorPhotos = fakePhotos.Where(photo => photo.ActorId.Equals(actor.ActorId)).ToList();
				actorViewModels.Add(new ActorViewModel(actor, curActorPhotos));
			}

			return actorViewModels;
		}
	}
}