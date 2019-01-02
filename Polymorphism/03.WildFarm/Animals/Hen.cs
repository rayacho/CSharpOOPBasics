using _03.WildFarm.Animals.Type;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Animals
{
	class Hen : Bird
	{
		public Hen(string name, double weight, double wingSize)
			: base(name, weight, wingSize) { }

		protected override double WeightIncreaseMultiplier => 0.35;

		public override string MakeSound()
		{
			return "Cluck";
		}
	}
}
