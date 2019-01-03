﻿using ExamPreparation.Units.Provider;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPreparation.Factories
{
	public class ProviderFactory
	{
		public Provider CreateProvider(List<string> arguments)
		{
			string type = arguments[0];
			string id = arguments[1];
			double energyOutput = double.Parse(arguments[2]);		

			switch (type)
			{
				case "Solar":
					return new SolarProvider(id, energyOutput);

				case "Pressure":
					return new PressureProvider(id, energyOutput);

				default:
					throw new ArgumentException();
			}
		}
	}
}
