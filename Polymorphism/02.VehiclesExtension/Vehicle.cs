using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
	public abstract class Vehicle
	{
		private double _fuelQuantity;
		private double _fuelConsumption;
		private double _tankCapacity;

		protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
		{
			FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
			FuelConsumption = fuelConsumption;
			TankCapacity = tankCapacity;
		}


		public double FuelQuantity
		{
			get
			{
				return _fuelQuantity;
			}
			set
			{
				_fuelQuantity = value;
			}
		}

		public double TankCapacity
		{
			get
			{
				return _tankCapacity;
			}
			set
			{
				Validator.CheckPositiveNumber(value);
				_tankCapacity = value;
			}
		}

		public double FuelConsumption
		{
			get
			{
				return _fuelConsumption;
			}
			set
			{
				_fuelConsumption = value;
			}
		}

		public abstract void Drive(double distance);

		public abstract void Refuel(double liters);

		public override string ToString()
		{
			return $"{GetType().Name}: {FuelQuantity:F2}";
		}
	}
}
