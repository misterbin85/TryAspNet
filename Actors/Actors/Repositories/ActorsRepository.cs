using System.Collections.Generic;
using Actors.Models;

namespace Actors.Repositories
{
    public class ActorsRepository
    {
        public static List<Actor> GetAllActors()
        {
            return new List<Actor>
            {
                new Actor{ ActorId = 1, FullName = "TestActor Name", ActorGender = Actor.Gender.female, Photo = @"~/some path_1"},

                new Actor{ ActorId = 1, FullName = "TestActor Name", ActorGender = Actor.Gender.male, Photo = @"~/some path_2"},
            };
        }
    }
}