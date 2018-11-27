using System;
using System.Collections.Generic;
using System.Text;

namespace _12.Google
{
	public class Child
	{
		private string _name;
		private string _birthday;

		public Child(string name, string birthday)
		{
			Name = name;
			_birthday = birthday;
		}

		private string Name
		{
			set
			{
				if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException($"{nameof(Child)}'s name can not be neither empty nor white space!!!");
				}

				_name = value;
			}
		}

		public override string ToString()
		{
			return $"{_name} {_birthday}";
		}
	}
}
