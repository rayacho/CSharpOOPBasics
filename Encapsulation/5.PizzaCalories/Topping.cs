using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.PizzaCalories
{
	class Topping
	{
		private const int minWeight = 1;
		private const int maxWeight = 50;
		private const int defaultMultiplier = 2;

		private Dictionary<string, double> validTypes = new Dictionary<string, double>
		{
			["meat"] = 1.2,
			["veggies"] = 0.8,
			["cheese"] = 1.1,
			["sauce"] = 0.9,
		};

		private string type;
		private double weight;

		public Topping(string type, double weight)
		{
			this.Type = type;
			ValidateWeight(type, weight);
			this.Weight = weight;
		}

		private double typeMultiplier => validTypes[type];
		public double Calories => defaultMultiplier * this.Weight * typeMultiplier;

		private void ValidateWeight(string type, double weight)
		{
			if (weight < minWeight || weight > maxWeight)
			{
				throw new ArgumentException($"{type} weight should be in the range [{minWeight}..{maxWeight}].");
			}
		}

		public string Type
		{
			get { return type; }
			set
			{
				if (!this.validTypes.Any(t => t.Key == value.ToLower()))
				{
					throw new ArgumentException($"Cannot place {value} on top of your pizza.");
				}

				type = value.ToLower();
			}
		}

		public double Weight
		{
			get { return weight; }
			set
			{
				weight = value;
			}
		}
	}
}
