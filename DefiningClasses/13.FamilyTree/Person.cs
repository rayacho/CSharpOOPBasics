using System;
using System.Collections.Generic;
using System.Text;

namespace _13.FamilyTree
{
	public class Person
	{
		private string name;
		private string birthday;
		private List<Person> parents;
		private List<Person> children;

		public Person()
		{
			this.children = new List<Person>();
			this.Parents = new List<Person>();
		}

		public Person(string name)
			: this()
		{
			this.name = name;
		}

		public string FullName
		{
			get { return name; }
			set { name = value; }
		}

		public string Birthday
		{
			get { return birthday; }
			set { birthday = value; }
		}

		public List<Person> Parents
		{
			get { return parents; }
			set { parents = value; }
		}

		public List<Person> Children
		{
			get { return children; }
			set { children = value; }
		}

		public static Person CreatePerson(string personInput)

		{
			Person person = new Person();

			if (IsBirthday(personInput))
			{
				person.Birthday = personInput;
			}
			else
			{
				person.FullName = personInput;
			}

			return person;
		}

		private static bool IsBirthday(string input)
		{
			return Char.IsDigit(input[0]);
		}

		public override string ToString()
		{
			return $"{this.FullName} {this.Birthday}";
		}
	}
}
