using System;
using System.Collections.Generic;
using System.Text;

namespace _06.BirthdayCelebrations
{
	public class Human : IId, IHuman, IBirthdate
	{
		public Human(string name, int age, string id, string birthday)
		{
			Name = name;
			Age = age;
			Id = id;
			Birthday = birthday;
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

		public string Birthday
		{
			get;
		}
	}
}
