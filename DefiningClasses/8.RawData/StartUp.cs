using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.RawData
{
	public class StartUp
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			List<Car> cars = new List<Car>();

			for (int i = 0; i < n; i++)
			{
				string[] inputArgs = Console.ReadLine().Split(' ');
				string model = inputArgs[0];
				int engineSpeed = int.Parse(inputArgs[1]);
				int enginePower = int.Parse(inputArgs[2]);
				int cargoWeight = int.Parse(inputArgs[3]);
				string cargoType = inputArgs[4];
				List<Tire> tires = new List<Tire>();
				double firstTirePressure = double.Parse(inputArgs[5]);
				int firstTireAge = int.Parse(inputArgs[6]);
				double secondTirePressure = double.Parse(inputArgs[7]);
				int secondTireAge = int.Parse(inputArgs[8]);
				double thirdTirePressure = double.Parse(inputArgs[9]);
				int thirdTireAge = int.Parse(inputArgs[10]);
				double fourthTirePressure = double.Parse(inputArgs[11]);
				int fourthTireAge = int.Parse(inputArgs[12]);

				Tire firstTire = new Tire(firstTireAge, firstTirePressure);
				Tire secondTire = new Tire(secondTireAge, secondTirePressure);
				Tire thirdTire = new Tire(thirdTireAge, thirdTirePressure);
				Tire fourthTire = new Tire(fourthTireAge, fourthTirePressure);
				tires.Add(firstTire);
				tires.Add(secondTire);
				tires.Add(thirdTire);
				tires.Add(fourthTire);

				//for (int j = 0; j <= 6; j += 2)
				//{
				//	double tirePressure = double.Parse(inputArgs[5 + j]);
				//	int tireAge = int.Parse(inputArgs[6 + j]);

				//	Tire tire = new Tire(tireAge, tirePressure);
				//	tires.Add(tire);
				//}

				Engine engine = new Engine(engineSpeed, enginePower);
				Cargo cargo = new Cargo(cargoWeight, cargoType);
				Car car = new Car(model, engine, cargo, tires);
				cars.Add(car);

			}

			string command = Console.ReadLine();
			List<Car> resultCars = new List<Car>();

			if (command == "fragile")
			{
				resultCars = cars.Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(s => s.Pressure < 1)).ToList();
			}
			else
			{
				resultCars = cars.Where(x => x.Cargo.CargoType == "flamable" && x.Engine.Power > 250).ToList();
			}

			foreach (var c in resultCars)
			{
				Console.WriteLine(c.Model);
			}
		}
	}
}
