using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Animals.Type
{
	abstract class Feline : Mammal
	{
		public Feline(string name, double weight, string livingRegion, string breed)
			: base(name, weight, livingRegion)
		{
			Breed = breed;
		}

		protected string Breed { get; set; }

		public override string ToString()
		{
			string fromBase = base.ToString();
			string result = string.Format(fromBase, $"{Breed}, ");
			return result;
		}
	}
}
