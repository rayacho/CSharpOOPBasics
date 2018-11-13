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

		public override string ToString()
		{
			return $"{this.FullName} {this.Birthday}";
		}
	}
}
