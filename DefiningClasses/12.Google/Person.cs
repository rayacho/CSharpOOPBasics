using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _12.Google
{
	public class Person
	{
		private string _name;
		private Company _company;
		private Car _car;
		private Queue<Pokemon> _pokemons;
		private Queue<Parent> _parents;
		private Queue<Child> _children;

		public Person(string name)
		{
			Name = name;
			_pokemons = new Queue<Pokemon>();
			_parents = new Queue<Parent>();
			_children = new Queue<Child>();
		}

		public string Name
		{
			get
			{
				return _name;
			}

			private set
			{
				if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException($"{nameof(Person)}'s name can not be neither empty nor white space!!!");
				}

				_name = value;
			}
		}

		public void AssignACompany(Company company)
		{
			_company = company;
		}

		public void AssignACar(Car car)
		{
			_car = car;
		}

		public void AddInCollection(Pokemon pokemon)
		{
			_pokemons.Enqueue(pokemon);
		}

		public void AddInCollection(Parent parent)
		{
			_parents.Enqueue(parent);
		}

		public void AddInCollection(Child child)
		{
			_children.Enqueue(child);
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine(_name);

			sb.AppendLine("Company:");
			if (_company != null)
			{
				sb.AppendLine(this._company.ToString());
			}

			sb.AppendLine("Car:");
			if (_car != null)
			{
				sb.AppendLine(this._car.ToString());
			}

			sb.AppendLine("Pokemon:");
			if (_pokemons.Count > 0)
			{
				sb.AppendLine(string.Join(Environment.NewLine, this._pokemons.Select(pok => pok.ToString())));
			}

			sb.AppendLine("Parents:");
			if (_parents.Count > 0)
			{
				sb.AppendLine(string.Join(Environment.NewLine, this._parents.Select(par => par.ToString())));
			}

			sb.AppendLine("Children:");
			if (_children.Count > 0)
			{
				sb.AppendLine(string.Join(Environment.NewLine, this._children.Select(c => c.ToString())));
			}

			return sb.ToString();
		}
	}
}
