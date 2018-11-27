using System;
using System.Collections.Generic;
using System.Text;

namespace _12.Google
{
	public class Pokemon
	{
		private string _name;
		private string _type;

		public Pokemon(string name, string type)
		{
			_name = name;
			_type = type;
		}

		public override string ToString()
		{
			return $"{_name} {_type}";
		}
	}
}
