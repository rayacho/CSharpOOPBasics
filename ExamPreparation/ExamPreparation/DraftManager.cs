using ExamPreparation.Factories;
using ExamPreparation.Units;
using ExamPreparation.Units.Harvester;
using ExamPreparation.Units.Provider;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPreparation
{
	public class DraftManager
	{
		private List<Harvester> _harvesters;
		private List<Provider> _providers;
		private HarvesterFactory _harvesterFactory;
		private ProviderFactory _providerFactory;
		private string _mode;
		private double _totalEnergyStored;
		private double _totalMinedOre;

		public DraftManager()
		{
			_harvesters = new List<Harvester>();
			_providers = new List<Provider>();
			_harvesterFactory = new HarvesterFactory();
			_providerFactory = new ProviderFactory();	
			_mode = "Full";
			_totalEnergyStored = 0;
			_totalMinedOre = 0;
		}

		public string RegisterHarvester(List<string> arguments)
		{
			try
			{
				Harvester harvester = _harvesterFactory.CreateHarvester(arguments);
				_harvesters.Add(harvester);
				return $"Successfully registered {harvester.Type} Harvester - {harvester.Id}.";
			}
			catch (ArgumentException ex)
			{
				return ex.Message;
			}
		}

		public string RegisterProvider(List<string> arguments)
		{
			try
			{
				Provider provider = _providerFactory.CreateProvider(arguments);
				_providers.Add(provider);
				return $"Successfully registered {provider.Type} Provider - {provider.Id}.";
			}
			catch (ArgumentException ex)
			{
				return ex.Message;
			}
		}

		public string Day()
		{
			double dayEnergyProvided = _providers.Sum(p => p.EnergyOutput);
			_totalEnergyStored += dayEnergyProvided;
			double dayEnergyRquired, dayMinedOre;

			if (_mode == "Full")
			{
				dayEnergyRquired = _harvesters.Sum(h => h.EnergyRequirement);
				dayMinedOre = _harvesters.Sum(h => h.OreOutput);
			}
			else if (_mode == "Half")
			{
				dayEnergyRquired = _harvesters.Sum(h => h.EnergyRequirement) * 0.6;
				dayMinedOre = _harvesters.Sum(h => h.OreOutput) * 0.5;
			}
			else
			{
				dayEnergyRquired = 0;
				dayMinedOre = 0;
			}

			double realDayMinedOre = 0;

			if (_totalEnergyStored >= dayEnergyRquired)
			{
				_totalMinedOre += dayMinedOre;
				_totalEnergyStored -= dayEnergyRquired;
				realDayMinedOre = dayMinedOre;
			}

			return $"A day has passed." + Environment.NewLine +
			$"Energy Provided: { dayEnergyProvided}" + Environment.NewLine +
			$"Plumbus Ore Mined: {realDayMinedOre   }";
		}

		public string Mode(List<string> arguments)
		{
			_mode = arguments[0];
			return $"Successfully changed working mode to {_mode} Mode";
		}

		public string Check(List<string> arguments)
		{
			string id = arguments[0];
			Unit unit = (Unit)_harvesters.FirstOrDefault(h => h.Id == id) ??
				_providers.FirstOrDefault(p => p.Id == id);

			if (unit != null)
			{
				return unit.ToString();
			}
			else
			{
				return $"No element found with id - {id}";
			}
		}

		public string ShutDown()
		{
			return $"System Shutdown " + Environment.NewLine +
				$"Total Energy Stored: { _totalEnergyStored}" + Environment.NewLine +
				$"Total Mined Plumbus Ore: { _totalMinedOre}";
		}
	}
}
