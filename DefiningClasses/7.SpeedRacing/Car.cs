using System;
using System.Collections.Generic;
using System.Text;

namespace _7.SpeedRacing
{
	class Car
	{
		private string _model;
		private double _fuelAmount;
		private double _fuelConsumptionPerKm;
		private double _distanceTravelled;

		public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
		{
			_model = model;
			_fuelAmount = fuelAmount;
			_fuelConsumptionPerKm = fuelConsumptionPerKm;
			_distanceTravelled = 0.0;
		}

		public string Model
		{
			get { return _model; }
		}

		public double FuelAmount
		{
			get { return _fuelAmount; }
			set { _fuelAmount = value; }
		}

		public double FuelConsumptionPerKm
		{
			get { return _fuelConsumptionPerKm; }
		}

		public double DistanceTravelled
		{
			get { return _distanceTravelled; }
			set { _distanceTravelled = value; }
		}

		public void Drive(double kilometers)
		{
			var neededFuel = kilometers * _fuelConsumptionPerKm;

			if (this._fuelAmount < neededFuel)
			{
				Console.WriteLine("Insufficient fuel for the drive");
				return;
			}

			_fuelAmount -= neededFuel;
			_distanceTravelled += kilometers;
		}
	}
}
