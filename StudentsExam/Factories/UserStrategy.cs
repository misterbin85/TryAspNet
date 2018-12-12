using StudentsExam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsExam.Factories
{
	public class UserStrategy
	{
		public static IUser RetrieveUser(int option) => (IUser)Activator.CreateInstance(AvailableUserTypes()[option]);

		public static Dictionary<int, Type> AvailableUserTypes()
		{
			List<Type> entities = GetAllEntities();
			var users = new Dictionary<int, Type>();

			for (int i = 0; i < entities.Count; i++)
			{
				var loc = i;
				users.Add(loc, entities[loc]);
			}

			return users;
		}

		private static List<Type> GetAllEntities() => AppDomain.CurrentDomain.GetAssemblies()
			.SelectMany(assembly => assembly.GetTypes())
			.Where(type => typeof(IUser).IsAssignableFrom(type) && !type.IsInterface).ToList();
	}
}