using System.Data.Entity;

namespace Actors.DataAccess
{
	public class ActorsDb : DbContext
	{
		public ActorsDb()
		: base("ActorsDb")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Actor>()
				.HasMany(a => a.Photos)
				.WithRequired(p => p.Actor)
				.Map(m =>
				{
					m.MapKey(nameof(Photo.ActorId), nameof(Actor.Id));
				});
		}

		public DbSet<Actor> Actors { get; set; }

		public DbSet<Photo> Photos { get; set; }
	}
}