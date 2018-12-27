using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
	public class Citizen : IId, ICitizen
	{
		public Citizen(string name, int age, string id)
		{
			Name = name;
			Age = age;
			Id = id;
		}

		public string Name
		{
			get;
		}

		public int Age
		{
			get;
		}

		public string Id
		{
			get;
		}
	}
}
