using System;
using System.Collections.Generic;
using System.Text;

namespace Structure.Models
{
	public abstract class Driver
	{
		private const double boxDefaultTime = 20;

		protected Driver(string name, Car car, double fuelConsumption)
		{
			Name = name;
			Car = car;
			FuelConsumptionPerKm = fuelConsumption;
			TotalTime = 0d;
			IsRacing = true;
		}

		public string Name { get; }

		public double TotalTime { get; set; }

		public Car Car { get; }

		public double FuelConsumptionPerKm { get; }

		public virtual double Speed => (Car.Hp + Car.Tyre.Degradation) / Car.FuelAmount;

		public string FailureReason { get; private set; }

		public bool IsRacing { get; private set; }

		private string Status => IsRacing ? TotalTime.ToString("f3") : FailureReason;

		private void Box()
		{
			TotalTime += boxDefaultTime;
		}

		internal void Refuel(string[] methodArgs)
		{
			Box();

			double fuelAmount = double.Parse(methodArgs[0]);

			Car.Refuel(fuelAmount);
		}

		internal void ChangeTyres(Tyre tyre)
		{
			Box();

			Car.ChangeTyres(tyre);
		}

		public override string ToString()
		{
			return $"{Name} {Status}";
		}

		internal void CompleteLap(int trackLength)
		{
			TotalTime += 60 / (trackLength / Speed);

			Car.CompleteLap(trackLength, FuelConsumptionPerKm);
		}

		internal void Fail(string message)
		{
			IsRacing = false;
			FailureReason = message;
		}
	}
}
