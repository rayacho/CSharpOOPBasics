using System;
using System.Collections.Generic;
using System.Text;

namespace _5.PizzaCalories
{
	class Dough
	{
		private string flourType;
		double caloriesPerGram = 1;
		public string FlourType
		{
			get { return flourType; }
			set
			{
				switch(value)
				{
					case "white":
						caloriesPerGram *= 1.5;
						break;
					case "wholegrain":
						caloriesPerGram *= 1.5;
						break;
					case "white":
						caloriesPerGram *= 1.5;
						break;
				}
				flourType = value;
			}
		}

	}
}
