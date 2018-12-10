using System;
using System.Collections.Generic;
using System.Text;

namespace _13.FamilyTree
{
	public class Person
	{
		private string _name;
		private string _birthday;
		private List<Person> _parents;
		private List<Person> _children;

		public Person()
		{
			_children = new List<Person>();
			Parents = new List<Person>();
		}

		public Person(string name)	:	this()
		{
			_name = name;
		}

		public string FullName
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public string Birthday
		{
			get
			{
				return _birthday;
			}
			set
			{
				_birthday = value;
			}
		}

		public List<Person> Parents
		{
			get
			{
				return _parents;
			}
			set
			{
				_parents = value;
			}
		}

		public List<Person> Children
		{
			get
			{
				return _children;
			}
			set
			{
				_children = value;
			}
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
			return $"{FullName} {Birthday}";
		}
	}
}
