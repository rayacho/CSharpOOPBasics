using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Structure
{
	public class Engine
	{
		private RaceTower _raceTower;

		public Engine(RaceTower raceTower)
		{
			_raceTower = raceTower;
		}

		internal void Run()
		{
			while (!_raceTower.IsRaceOver)
			{
				string[] commandArgs = Console.ReadLine().Split();
				string commandtype = commandArgs[0];
				List<string> methodArgs = commandArgs.Skip(1).ToList();

				switch (commandtype)
				{
					case "RegisterDriver":
						_raceTower.RegisterDriver(methodArgs);
						break;
					case "Leaderboard":
						Console.WriteLine(_raceTower.GetLeaderboard());
						break;
					case "CompleteLaps":
						string result = _raceTower.CompleteLaps(methodArgs);
						if (!string.IsNullOrWhiteSpace(result))
						{
							Console.WriteLine(result);
						}
						break;
					case "Box":
						_raceTower.DriverBoxes(methodArgs);
						break;
					case "ChangeWeather":
						_raceTower.ChangeWeather(methodArgs);
						break;
					default:
						Console.WriteLine("INVALID COMMAND");
						break;
				}
			}
		}
	}
}
