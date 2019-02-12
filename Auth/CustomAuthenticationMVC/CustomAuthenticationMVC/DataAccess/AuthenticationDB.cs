using System.Data.Entity;

namespace CustomAuthenticationMVC.DataAccess
{
	public class AuthenticationDB : DbContext
	{
		public AuthenticationDB()
			: base("AuthenticationDB")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.HasMany(u => u.Roles)
				.WithMany(r => r.Users)
				.Map(m =>
				{
					m.ToTable("UserRoles");
					m.MapLeftKey("UserId");
					m.MapRightKey("RoleId");
				});

			modelBuilder.Entity<Question>()
				.HasMany(q => q.PossibleAnswers)
				.WithRequired(a => a.Question)
				.Map(m =>
				{
					m.MapKey(nameof(Question.Id), nameof(Answer.Id));
				});
		}

		public DbSet<User> Users { get; set; }

		public DbSet<Role> Roles { get; set; }

		public DbSet<Question> Questions { get; set; }

		public DbSet<Answer> Answers { get; set; }
	}
}