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
				new Actor { FullName = "������ ����", FullInfo = "Info goes here", Gender = "female" },
				new Actor { FullName = "�������� ������", FullInfo = "Info goes here", Gender = "male" },
				new Actor { FullName = "������� ������", FullInfo = "Info goes here", Gender = "male" }
			);
		}
	}
}
