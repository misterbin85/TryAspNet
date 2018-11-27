using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTestMVC.Models
{
	public class PersonModel
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public int Age { get; set; } = 12;

		public bool IsAlive { get; set; } = true;
	}
}