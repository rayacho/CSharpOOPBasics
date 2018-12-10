using System;
using System.Collections.Generic;
using System.Text;

namespace _8.RawData
{
	public class Tire
	{
		private int _age;
		private double _pressure;

		public Tire(int age, double pressure)
		{
			Age = age;
			Pressure = pressure;
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

		public double Pressure
		{
			get
			{
				return _pressure;
			}
			set
			{
				_pressure = value;
			}
		}

	}
}
