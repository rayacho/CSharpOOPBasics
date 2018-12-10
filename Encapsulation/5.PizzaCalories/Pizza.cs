using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.PizzaCalories
{
	class Pizza
	{
		private const int minLength = 1;
		private const int maxLength = 15;
		private const int minTopping = 0;
		private const int maxTopping = 10;
		private string name;

		public Pizza()
		{
			Toppings = new List<Topping>();
		}

		public Pizza(string name) : this()
		{
			Name = name;
		}

		private double ToppingsCalories
		{
			get
			{
				if (Toppings.Count == 0)
				{
					return 0;
				}

				return Toppings.Select(t => t.Calories).Sum();
			}
		}

		private double Calories => Dough.Calories + ToppingsCalories;

		private string Name
		{
			get
			{
				return name;
			}
			set
			{
				if (string.IsNullOrEmpty(value) || value.Length > maxLength)
				{
					throw new ArgumentException($"Pizza name should be between {minLength} and {maxLength} symbols.");
				}

				name = value;
			}
		}

		private Dough Dough { get; set; }
		private List<Topping> Toppings { get; set; }

		public void SetDough(Dough dough)
		{
			Dough = dough;
		}

		public void AddToping(Topping topping)
		{
			if (Toppings.Count > maxTopping)
			{
				throw new ArgumentException($"Number of toppings should be in range [{minTopping}..{maxTopping}].");

			}

			Toppings.Add(topping);
		}

		public override string ToString()
		{
			return $"{Name} - {Calories:f2} Calories.";
		}
	}
}
