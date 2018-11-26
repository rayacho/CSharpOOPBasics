using System;
using System.Collections.Generic;
using System.Text;

namespace _2.CarsSalesman
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
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("{0}:\n", _model);
			sb.Append(_engine.ToString());
			sb.AppendFormat("{0}Weight: {1}\n", OFFSET, _weight == -1 ? "n/a" : _weight.ToString());
			sb.AppendFormat("{0}Color: {1}", OFFSET, _color);

			return sb.ToString();
		}
	}
}
