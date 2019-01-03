using _03.WildFarm.Animals.Type;
using _03.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Animals
{
	class Owl : Bird
	{
		public Owl(string name, double weight, double wingSize)
			: base(name, weight, wingSize) { }

		protected override Type[] PreferredFoods
		{
			get
			{
				return new Type[] { typeof(Meat) };
			}
		}

		protected override double WeightIncreaseMultiplier => 0.25;

		public override string MakeSound()
		{
			return "Hoot Hoot";
		}
	}
}
