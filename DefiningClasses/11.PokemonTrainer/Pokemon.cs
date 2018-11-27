using System;
using System.Collections.Generic;
using System.Text;

namespace _11.PokemonTrainer
{
	class Pokemon
	{
		private string _name;
		private string _element;
		private int _health;

		public Pokemon(string name, string element, int health)
		{
			_name = name;
			_element = element;
			_health = health;
		}

		public int Health { get { return _health; } }

		public string Element { get { return _element; } }

		public void ReduceHealth()
		{
			_health -= 10;
		}
	}
}
