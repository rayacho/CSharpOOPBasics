using System;
using System.Collections.Generic;
using System.Text;

namespace _12.Google
{
	public class Car
	{
		private string _model;
		private int _speed;

		public Car(string model, int speed)
		{
			_model = model;
			_speed = speed;
		}

		public override string ToString()
		{
			return $"{_model} {_speed}";
		}
	}
}
