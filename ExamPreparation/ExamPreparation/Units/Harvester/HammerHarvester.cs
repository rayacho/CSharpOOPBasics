﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPreparation.Units.Harvester
{
	public class HammerHarvester : Harvester
	{
		public override string Type => "Hammer";

		public HammerHarvester(string id, double oreOutput, double energyRequirement)
			: base(id, oreOutput * 3, energyRequirement * 2) { }
	}
}
