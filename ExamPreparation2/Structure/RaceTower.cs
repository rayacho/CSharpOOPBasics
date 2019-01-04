using Structure.Factories;
using Structure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Structure
{
	public class RaceTower
	{
		private const string crashReason = "Crashed";
		private TyreFactory _tyreFactory;
		private DriveFactory _driverFactory;
		private IList<Driver> _racingDrivers;
		private Stack<Driver> _failedDrivers;
		private Track _track;

		public RaceTower()
		{
			_tyreFactory = new TyreFactory();
			_driverFactory = new DriveFactory();
			_racingDrivers = new List<Driver>();
			_failedDrivers = new Stack<Driver>();
		}

		public bool IsRaceOver => this._track.CurrentLap == this._track.LapsNumber;

		public void SetTrackInfo(int lapsNumber, int trackLength)
		{
			_track = new Track(lapsNumber, trackLength);
		}
		public void RegisterDriver(List<string> commandArgs)
		{
			try
			{
				string driverType = commandArgs[0];
				string driverName = commandArgs[1];

				int horsePower = int.Parse(commandArgs[2]);
				double fuelAmoount = double.Parse(commandArgs[3]);

				string[] tyreArgs = commandArgs.Skip(4).ToArray();

				Tyre tyre = _tyreFactory.CreateTyre(tyreArgs);

				Car car = new Car(horsePower, fuelAmoount, tyre);

				Driver driver = _driverFactory.CreateDriver(driverType, driverName, car);

				_racingDrivers.Add(driver);
			}
			catch { }
		}

		public void DriverBoxes(List<string> commandArgs)
		{
			string boxReason = commandArgs[0];
			string driverName = commandArgs[1];

			Driver driver = _racingDrivers.FirstOrDefault(d => d.Name == driverName);

			string[] methodArgs = commandArgs.Skip(2).ToArray();

			if (boxReason == "Refuel")
			{
				driver.Refuel(methodArgs);
			}
			else if (boxReason == "ChangeTyres")
			{
				Tyre tyre = _tyreFactory.CreateTyre(methodArgs);
				driver.ChangeTyres(tyre);
			}
		}

		public string CompleteLaps(List<string> commandArgs)
		{
			StringBuilder builder = new StringBuilder();
			int numberOfLaps = int.Parse(commandArgs[0]);

			if (numberOfLaps > _track.LapsNumber - _track.CurrentLap)
			{
				try
				{
					throw new ArgumentException(string.Format(OutputMessages.InvalidLaps, this._track.CurrentLap));
				}
				catch (ArgumentException e)
				{
					return e.Message;
				}
			}

			for (int lap = 0; lap < numberOfLaps; lap++)
			{
				for (int index = 0; index < _racingDrivers.Count; index++)
				{
					Driver driver = _racingDrivers[index];

					try
					{
						driver.CompleteLap(_track.TrackLength);
					}
					catch (ArgumentException e)
					{
						driver.Fail(e.Message);
						_failedDrivers.Push(driver);
						_racingDrivers.RemoveAt(index);
						index--;
					}
				}

				_track.CurrentLap++;


				List<Driver> orderedDrivers = this._racingDrivers
					.OrderByDescending(d => d.TotalTime)
					.ToList();

				for (int index = 0; index < orderedDrivers.Count - 1; index++)
				{
					Driver overtakingDriver = orderedDrivers[index];
					Driver targetDriver = orderedDrivers[index + 1];

					bool overtakeHappened = this.TryOverTake(overtakingDriver, targetDriver);

					if (overtakeHappened)
					{
						index++;
						builder.AppendLine(string.Format
							(OutputMessages.OvertakeMessage, overtakingDriver.Name, targetDriver.Name, _track.CurrentLap));
					}
					else
					{
						if (!overtakingDriver.IsRacing)
						{
							_failedDrivers.Push(overtakingDriver);
							_racingDrivers.Remove(overtakingDriver);
						}
					}
				}
			}

			if (IsRaceOver)
			{
				Driver winner = _racingDrivers.OrderBy(d => d.TotalTime).First();
				builder.AppendLine(
					string.Format(OutputMessages.WinnerMessage, winner.Name, winner.TotalTime));
			}

			string result = builder.ToString().TrimEnd();
			return result;
		}

		private bool TryOverTake(Driver overtakingDriver, Driver targetDriver)
		{
			double timeDiff = overtakingDriver.TotalTime - targetDriver.TotalTime;

			bool aggressiveDriver = overtakingDriver is AggressiveDriver &&
				overtakingDriver.Car.Tyre is UltrasoftTyre;

			bool enduranceDriver = overtakingDriver is EnduranceDriver &&
				overtakingDriver.Car.Tyre is HardTyre;

			bool crash = (aggressiveDriver && _track.Weather == Weather.Foggy) ||
				(enduranceDriver && _track.Weather == Weather.Rainy);

			if ((aggressiveDriver || enduranceDriver) && timeDiff <= 3)
			{
				if (crash)
				{
					overtakingDriver.Fail(crashReason);
					return false;
				}

				overtakingDriver.TotalTime -= 3;
				targetDriver.TotalTime += 3;
				return true;
			}
			else if (timeDiff <= 2)
			{
				overtakingDriver.TotalTime -= 2;
				targetDriver.TotalTime += 2;
				return true;
			}

			return false;
		}

		public string GetLeaderboard()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine($"Lap {this._track.CurrentLap}/{this._track.LapsNumber}");

			IEnumerable<Driver> leaderboardDrivers = this._racingDrivers
				.OrderBy(d => d.TotalTime)
				.Concat(this._failedDrivers);

			int position = 1;

			foreach (Driver driver in leaderboardDrivers)
			{
				builder.AppendLine($"{position} {driver.ToString()}");
				position++;
			}

			string result = builder.ToString().TrimEnd();
			return result;
		}

		public void ChangeWeather(List<string> commandArgs)
		{
			string weatherType = commandArgs[0];

			bool validWeather = Enum.TryParse(typeof(Weather), weatherType, out object weatherObj);

			if (!validWeather)
			{
				throw new ArgumentException(OutputMessages.InvalidWeatherType);
			}

			Weather weather = (Weather)weatherObj;
			_track.Weather = weather;
		}
	}
}
