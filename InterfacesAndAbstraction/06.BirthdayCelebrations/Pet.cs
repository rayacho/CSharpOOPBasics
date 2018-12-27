using System;
using System.Collections.Generic;
using System.Text;

namespace _06.BirthdayCelebrations
{
	public class Pet : IPet, IBirthdate
	{
		public Pet(string name, string birthday)
		{
			Name = name;
			Birthday = birthday;
		}

		public string Name
		{
			get;
		}

		public string Birthday
		{
			get;
		}
	}
}
