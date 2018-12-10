using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6.FootballTeamGenerator
{
	class Team
	{
		private string _name;
		private HashSet<Player> _players;

		public Team(string name)
		{
			Name = name;
			_players = new HashSet<Player>();
		}

		public string Name
		{
			get
			{
				return _name;
			}
			private set
			{
				if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
				{
					throw new ArgumentException("A name should not be empty.");
				}

				_name = value;
			}
		}

		public double GetRating()
		{
			if (_players.Count > 0)
			{
				return _players.Select(p => p.SkillLevel).Average();
			}
			else
			{
				return 0;
			}
		}

		internal void AddPlayer(Player player)
		{
			_players.Add(player);
		}

		internal bool IsPlayerFound(string playerName)
		{
			return _players.FirstOrDefault(p => p.Name == playerName) != null;
		}

		internal void RemovePlayer(string playerName)
		{
			if (this == null)
			{
				throw new NullReferenceException("Team does not existent");
			}

			if (_players.Any(p => p.Name == playerName))
			{
				_players.RemoveWhere(p => p.Name == playerName);
			}
			else
			{
				throw new InvalidOperationException($"Player {playerName} is not in {this.Name} team.");
			}
		}
	}
}
