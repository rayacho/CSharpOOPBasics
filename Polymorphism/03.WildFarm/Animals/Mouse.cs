using _03.WildFarm.Animals.Type;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Animals
{
	class Mouse : Mammal
	{
		public Mouse(string name, double weight, string livingRegion)
			: base(name, weight, livingRegion) { }

		protected override Type[] PreferredFoods => new Type[] { typeof(Vegetable), typeof(Fruit) };

		protected override double WeightIncreaseMultiplier => 0.10;

		public override string ToString()
		{
			string fromBase = base.ToString();
			string result = string.Format(fromBase, string.Empty);
			return result;
		}

		public override string MakeSound()
		{
			return "Squeak";
		}
	}
}
