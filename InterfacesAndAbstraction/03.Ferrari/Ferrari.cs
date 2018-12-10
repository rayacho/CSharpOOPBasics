using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Ferrari
{
	public class Ferrari : ICar
	{
		public Ferrari(string driver, string model)
		{
			Driver = driver;
			Model = model;
		}

		public string Driver { get; private set; }

		public string Model { get; private set; }

		public string Brakes()
		{
			return "/Brakes!/";
		}

		public string Gas()
		{
			return "Zadu6avam sA!/";
		}
	}
}
