using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPreparation.Units.Provider
{
	public class PressureProvider : Provider
	{
		public override string Type => "Pressure";

		public PressureProvider(string id, double energyOutput)
			: base(id, energyOutput * 1.5) { }
	}
}
