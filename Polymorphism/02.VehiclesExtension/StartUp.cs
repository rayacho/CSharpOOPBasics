using System;

namespace _02.VehiclesExtension
{
	class StartUp
	{
		private static Car _car;
		private static Truck _truck;
		private static Bus _bus;

		public static void Main()
		{
			ParseInput();

			int numberOfCommands = int.Parse(Console.ReadLine());

			ParseCommand(numberOfCommands);

			Console.WriteLine(_car);
			Console.WriteLine(_truck);
			Console.WriteLine(_bus);
		}

		private static void ParseInput()
		{
			string[] carParts = Console.ReadLine().Split(' ');
			string[] truckParts = Console.ReadLine().Split(' ');
			string[] busParts = Console.ReadLine().Split(' ');

			_car = new Car(double.Parse(carParts[1]), double.Parse(carParts[2]), double.Parse(carParts[3]));
			_truck = new Truck(double.Parse(truckParts[1]), double.Parse(truckParts[2]), double.Parse(truckParts[3]));
			_bus = new Bus(double.Parse(busParts[1]), double.Parse(busParts[2]), double.Parse(busParts[3]));
		}

		private static void ParseCommand(int numberOfCommands)
		{
			for (int i = 0; i < numberOfCommands; i++)
			{
				string[] commandParts = Console.ReadLine().Split(' ');
				string command = commandParts[0];

				switch (command)
				{
					case "Drive":
						DriveCommand(commandParts);
						break;

					case "Refuel":
						RefuelCommand(commandParts);
						break;

					case "DriveEmpty":
						_bus.DriveEmpty(double.Parse(commandParts[2]));
						break;
				}
			}
		}

		private static void RefuelCommand(string[] commandParts)
		{
			string vehicle = commandParts[1];

			switch (vehicle)
			{
				case "Car":
					_car.Refuel(double.Parse(commandParts[2]));
					break;

				case "Truck":
					_truck.Refuel(double.Parse(commandParts[2]));
					break;

				case "Bus":
					_bus.Refuel(double.Parse(commandParts[2]));
					break;
			}
		}

		private static void DriveCommand(string[] commandParts)
		{
			string vehicle = commandParts[1];

			switch (vehicle)
			{
				case "Car":
					_car.Drive(double.Parse(commandParts[2]));
					break;

				case "Truck":
					_truck.Drive(double.Parse(commandParts[2]));
					break;

				case "Bus":
					_bus.Drive(double.Parse(commandParts[2]));
					break;
			}
		}
	}
}