using Actors.DataAccess;
using Actors.Models;
using System.Collections.Generic;
using System.Linq;

namespace Actors.Repositories
{
	public class ActorsRepository
	{
		public static List<ActorViewModel> GetAllActors()
		{
			/*
            // fake data before DB implementation
            var fakeActors = new Faker<Actor>()
                .RuleFor(a => a.ActorId, f => f.UniqueIndex)
                .RuleFor(a => a.FullName, f => f.Internet.UserName())
                .RuleFor(a => a.ActorGender, f => f.PickRandom(new[] { "male", "female" }))
                .Generate(10).ToList();

			var fakePhotos = new Faker<PhotoModel>()
				.RuleFor(p => p.ActorId, f => f.PickRandom(new List<int>(actors.Select(a => a.Id))))
				.RuleFor(p => p.PhotoPath, f => f.Lorem.Word() + ".png")
				.RuleFor(p => p.PhotoId, f => f.UniqueIndex)
				.RuleFor(p => p.IsMain, f => f.PickRandom(new[] { true, false }))
				.Generate(50).ToList();
				*/

			List<ActorViewModel> actorViewModels = new List<ActorViewModel>();

			List<Actor> actors;
			List<Photo> photos;

			using (ActorsDb db = new ActorsDb())
			{
				actors = db.Actors.ToList();
				photos = db.Photos.ToList();
			}

			foreach (var actor in actors)
			{
				var curAuthorPhotos = photos.Where(p => p.ActorId.Equals(actor.Id)).Select(photo => new PhotoModel
				{
					PhotoId = photo.Id,
					PhotoPath = photo.Path,
					IsMain = photo.IsMain
				}).ToList();

				var curAct = new ActorModel
				{
					ActorId = actor.Id,
					FullName = actor.FullName,
					FullInfo = actor.FullInfo,
					ActorGender = actor.Gender
				};

				actorViewModels.Add(new ActorViewModel(curAct, curAuthorPhotos));
			}

			return actorViewModels;
		}
	}
}