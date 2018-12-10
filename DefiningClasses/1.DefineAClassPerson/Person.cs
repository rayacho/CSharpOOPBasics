using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
	public class Person
	{
		private string _name;
		private int _age;

		public string Name
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

		public int Age
		{
			get
			{
				return _age;
			}
			set
			{
				_age = value;
			}
		}

		public string NameAndAge()
		{
			return $"{_name} {_age}";
		}
	}
}