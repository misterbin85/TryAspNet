using Actors.DataAccess;

namespace Actors.Migrations
{
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<ActorsDb>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = true;
		}

		protected override void Seed(ActorsDb context)
		{
			context.Actors.AddOrUpdate(x => x.Id,
				new Actor { FullName = "Ардова Анна", FullInfo = "Info goes here", Gender = "female" },
				new Actor { FullName = "Безруков Сергей", FullInfo = "Info goes here", Gender = "male" },
				new Actor { FullName = "Хориняк Виктор", FullInfo = "Info goes here", Gender = "male" }
			);
		}
	}
}
