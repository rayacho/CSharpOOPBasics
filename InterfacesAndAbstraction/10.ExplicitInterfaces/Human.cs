using System;
using System.Collections.Generic;
using System.Text;

namespace _10.ExplicitInterfaces
{
	public class Human : IPerson, IResident
	{
		public Human(string name, string country, int age)
		{
			Name = name;
			Country = country;
			Age = age;
		}

		public string Name
		{
			get;
		}

		public string Country
		{
			get;
		}

		public int Age
		{
			get;
		}

		void IResident.GetName()
		{
			Console.WriteLine($"Mr/Ms/Mrs {Name}");
		}

		void IPerson.GetName()
		{
			Console.WriteLine($"{Name}");
		}
	}
}
