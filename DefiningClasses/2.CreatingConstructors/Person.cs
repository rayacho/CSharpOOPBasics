using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
	public class Person
	{
		private string name;
		private int age;

		public string Name
		{
			get { return this.name; }
		}

		public int Age
		{
			get { return this.age; }
		}

		public string FirstPerson()
		{
			name = "No name";
			age = 1;
			return ($"{name} {age}");
		}

		public string SecondPerson(int age)
		{
			name = "No name";
			this.age = age;
			return ($"{name} {age}");
		}

		public string ThirdPerson(string name, int age)
		{
			this.name = name;
			this.age = age;
			return ($"{name} {age}");
		}
	}
}