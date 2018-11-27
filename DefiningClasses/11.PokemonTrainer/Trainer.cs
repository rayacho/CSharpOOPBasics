using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PokemonTrainer
{
	class Trainer
	{
		private string _name;
		private int _badges;
		private Stack<Pokemon> _pokemons;

		public Trainer(string name)
		{
			this.Name = name;
			_badges = 0;
			_pokemons = new Stack<Pokemon>();
		}

		public Stack<Pokemon> Pokemons { get { return _pokemons; } }

		public string Name
		{
			get
			{
				return _name;
			}

			private set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException("Name can not be empty.");
				}

				_name = value;
			}
		}

		public int Badges { get { return _badges; } }

		public void AddABadge()
		{
			_badges++;
		}

		internal void ClearDeadPokemons()
		{
			if (_pokemons.Count > 0 && _pokemons.Where(p => p.Health <= 0).FirstOrDefault() != null)
			{
				_pokemons = new Stack<Pokemon>(_pokemons.Where(p => p.Health > 0));
			}
		}
	}
}
