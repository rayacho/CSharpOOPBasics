using System;
using System.Collections.Generic;
using System.Text;

namespace _02.CreatingConstructors
{
	public class Person
	{
		private string name;
		private int age;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public int Age
		{
			get { return age; }
			set { age = value; }
		}

		public string FirstNameAndAge()
		{
			name = "No name";
			age = 1;
			return $"{name} {age}";
		}

		public string SecondNameAndAge(int age)
		{
			name = "No name";
			return $"{name} {age}";
		}

		public string ThirdNameAndAge(string name, int age)
		{
			return $"{name} {age}";
		}
	}
}