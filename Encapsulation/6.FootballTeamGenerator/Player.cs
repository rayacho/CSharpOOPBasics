using System;
using System.Collections.Generic;
using System.Text;

namespace _6.FootballTeamGenerator
{
	class Player
	{
		private const int MinStatsValue = 0;
		private const int MaxStatsValue = 100;

		private string _name;
		private double _endurance;
		private double _sprint;
		private double _dribble;
		private double _passing;
		private double _shooting;
		private double _skillLevel;

		public Player(string name, double endurance, double sprint, double dribble, double passing, double shooting)
		{
			this.Name = name;
			this.Endurance = endurance;
			this.Sprint = sprint;
			this.Dribble = dribble;
			this.Passing = passing;
			this.Shooting = shooting;
			_skillLevel = (endurance + sprint + dribble + passing + shooting) / 5;
		}

		public string Name
		{
			get	{	return _name;	}

			private set
			{
				if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
				{
					throw new ArgumentException("A name should not be empty.");
				}

				_name = value;
			}
		}

		public double SkillLevel { get { return _skillLevel; } }

		private double Shooting
		{
			set
			{
				this.ValidateStat(value, nameof(this.Shooting));
				_shooting = value;
			}
		}

		private double Passing
		{
			set
			{
				this.ValidateStat(value, nameof(this.Passing));
				_passing = value;
			}
		}

		private double Dribble
		{
			set
			{
				this.ValidateStat(value, nameof(this.Dribble));
				_dribble = value;
			}
		}

		private double Sprint
		{
			set
			{
				this.ValidateStat(value, nameof(this.Sprint));
				_sprint = value;
			}
		}

		private double Endurance
		{
			set
			{
				this.ValidateStat(value, nameof(this.Endurance));
				_endurance = value;
			}
		}

		private void ValidateStat(double stat, string propertyName)
		{
			if (stat < MinStatsValue || stat > MaxStatsValue)
			{
				throw new ArgumentException($"{propertyName} should be between 0 and 100.");
			}
		}
	}
}
