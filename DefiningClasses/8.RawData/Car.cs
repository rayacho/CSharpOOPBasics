using System;
using System.Collections.Generic;
using System.Text;

namespace _8.RawData
{
	public class Car
	{
		private string _model;
		private Engine _engine;
		private Cargo _cargo;
		private List<Tire> _tires;

		public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
		{
			Model = model;
			Engine = engine;
			Cargo = cargo;
			Tires = tires;
		}

		public string Model
		{
			get { return _model; }
			set { _model = value; }
		}

		public Engine Engine
		{
			get { return _engine; }
			set { _engine = value; }
		}

		public Cargo Cargo
		{
			get { return _cargo; }
			set { _cargo = value; }
		}

		public List<Tire> Tires
		{
			get { return _tires; }
			set { _tires = value; }
		}
	}
}
