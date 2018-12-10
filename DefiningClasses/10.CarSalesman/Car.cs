using System;
using System.Collections.Generic;
using System.Text;

namespace _10.CarSalesman
{
	class Car
	{
		private const string OFFSET = "  ";
		public string _model;
		public Engine _engine;
		public int _weight;
		public string _color;

		public Car(string model, Engine engine)
		{
			_model = model;
			_engine = engine;
			_weight = -1;
			_color = "n/a";
		}

		public Car(string model, Engine engine, int weight)
		{
			_model = model;
			_engine = engine;
			_weight = weight;
			_color = "n/a";
		}

		public Car(string model, Engine engine, string color)
		{
			_model = model;
			_engine = engine;
			_weight = -1;
			_color = color;
		}

		public Car(string model, Engine engine, int weight, string color)
		{
			_model = model;
			_engine = engine;
			_weight = weight;
			_color = color;
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("{0}:\n", _model);
			builder.Append(_engine.ToString());
			builder.AppendFormat("{0}Weight: {1}\n", OFFSET, _weight == -1 ? "n/a" : _weight.ToString());
			builder.AppendFormat("{0}Color: {1}", OFFSET, _color);

			return builder.ToString();
		}
	}
}
