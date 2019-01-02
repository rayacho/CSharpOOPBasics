using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
	public class Truck : Vehicle
	{
		private const double _ACConsumption = 1.6;
		private const double _UsedFuel = 95;

		public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
			: base(fuelQuantity, fuelConsumption, tankCapacity) { }

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
			if (liters <= 0)
			{
				Console.WriteLine("Fuel must be a positive number");
			}
			else
			{
				double totalFuel = FuelQuantity + (liters * _UsedFuel / 100.0);

				if (totalFuel > TankCapacity)
				{
					Console.WriteLine($"Cannot fit {liters} fuel in the tank");
				}
				else
				{
					FuelQuantity += (liters * _UsedFuel / 100.0);
				}
			}
		}
	}
}