using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPreparation.Units.Harvester
{
	public abstract class Harvester : Unit
	{
		public const double maxEnergyRequirement = 10_000;
		private double oreOutput;
		private double energyRequirement;

		public double OreOutput
		{
			get
			{
				return oreOutput;
			}
			private set
			{
				if (value < 0)
				{
					throw new ArgumentException("Harvester is not registered, because of it's ОreOutput");
				}

				oreOutput = value;
			}
		}

		public double EnergyRequirement
		{
			get
			{
				return energyRequirement;
			}
			private set
			{
				if (value < 0 || value >= maxEnergyRequirement)
				{
					throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");
				}

				energyRequirement = value;
			}
		}

		protected Harvester(string id, double oreOutput, double energyRequirment)
			: base(id)
		{
			OreOutput = oreOutput;
			EnergyRequirement = energyRequirment;
		}

		public override string ToString()
		{
			return $"{Type} Harvester - {Id}" + Environment.NewLine +
				$"Ore Output: {OreOutput}" + Environment.NewLine +
				$"Energy Requirement: {energyRequirement}";
		}
	}
}
