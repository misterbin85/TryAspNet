using StudentsExam.Entities;
using System;
using System.Collections.Generic;

namespace StudentsExam.Helpers
{
	public class CustomArgs : EventArgs
	{
		public List<UserAnswer> Answers;

		public CustomArgs(List<UserAnswer> answers)
		{
			Answers = answers;
		}
	}
}
