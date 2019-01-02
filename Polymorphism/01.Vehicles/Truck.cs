using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
	public class Truck : Vehicle
	{
		private const double _ACConsumption = 1.6;
		private const double _UsedFuel = 95;

		public Truck(double fuelQuantity, double fuelConsumption)
			: base(fuelQuantity, fuelConsumption) { }

		public override void Drive(double distance)
		{
			double neededFuel = distance * (FuelConsumption + _ACConsumption);

			if (neededFuel <= FuelQuantity)
			{
				FuelQuantity -= neededFuel;
				Console.WriteLine($"Truck travelled {distance} km");
			}

			else
			{
				Console.WriteLine($"Truck needs refueling");
			}
		}

		public override void Refuel(double liters)
		{
			FuelQuantity += liters * _UsedFuel / 100.0;
		}
	}
}
