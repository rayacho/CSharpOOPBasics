using System;
using System.Collections.Generic;
using System.Text;

namespace _8.RawData
{
	public class Engine
	{
		private int _speed;
		private int _power; 

		public Engine(int speed, int power)
		{
			Speed = speed;
			Power = power;
		}

		public int Speed
		{
			get { return _speed; }
			set { _speed = value; }
		}

		public int Power
		{
			get { return _power; }
			set { _power = value; }
		}
	}
}
