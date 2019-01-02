using _03.WildFarm.Animals.Type;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Animals
{
	class Cat : Feline
	{
		public Cat(string name, double weight, string livingRegion, string breed)
			: base(name, weight, livingRegion, breed) { }

		protected override Type[] PreferredFoods => new Type[] { typeof(Meat), typeof(Vegetable) };

		protected override double WeightIncreaseMultiplier => 0.30;

		public override string MakeSound()
		{
			return "Meow";
		}
	}
}
