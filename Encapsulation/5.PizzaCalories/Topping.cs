using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.PizzaCalories
{
	class Topping
	{
		private const int _minWeight = 1;
		private const int _maxWeight = 50;
		private const int _defaultMultiplier = 2;
		private string _type;
		private double _weight;

		private Dictionary<string, double> validTypes = new Dictionary<string, double>
		{
			["meat"] = 1.2,
			["veggies"] = 0.8,
			["cheese"] = 1.1,
			["sauce"] = 0.9,
		};

		public Topping(string type, double weight)
		{
			Type = type;
			ValidateWeight(type, weight);
			Weight = weight;
		}

		private double typeMultiplier => validTypes[_type];
		public double Calories => _defaultMultiplier * Weight * typeMultiplier;

		private void ValidateWeight(string type, double weight)
		{
			if (weight < _minWeight || weight > _maxWeight)
			{
				throw new ArgumentException($"{type} weight should be in the range [{_minWeight}..{_maxWeight}].");
			}
		}

		public string Type
		{
			get
			{
				return _type;
			}
			set
			{
				if (!validTypes.Any(t => t.Key == value.ToLower()))
				{
					throw new ArgumentException($"Cannot place {value} on top of your pizza.");
				}

				_type = value.ToLower();
			}
		}

		public double Weight
		{
			get
			{
				return _weight;
			}
			set
			{
				_weight = value;
			}
		}
	}
}
