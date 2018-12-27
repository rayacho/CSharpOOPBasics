using System;
using System.Collections.Generic;
using System.Text;

namespace _07.FoodShortage
{
	public class Human : IId, IBirthdate, IBuyer
	{
		public Human(string name, int age, string id, string birthday)
		{
			Name = name;
			Age = age;
			Id = id;
			Birthday = birthday;
			Food = 0;
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

		public int Food
		{
			get;
			private set;
		}

		public void BuyFood()
		{
			Food += 10;
		}
	}
}
