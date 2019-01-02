using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
	public class Car : Vehicle
	{
		private const double _ACConsumption = 0.9;

		public Car(double fuelQuantity, double fuelConsumption)
			: base(fuelQuantity, fuelConsumption) { }

		public override void Drive(double distance)
		{
			double neededFuel = distance * (FuelConsumption + _ACConsumption);

			if (neededFuel <= FuelQuantity)
			{
				FuelQuantity -= neededFuel;
				Console.WriteLine($"Car travelled {distance} km");
			}
			else
			{
				Console.WriteLine($"Car needs refueling");
			}
		}

		public override void Refuel(double liters)
		{
			FuelQuantity += liters;
		}
	}
}
