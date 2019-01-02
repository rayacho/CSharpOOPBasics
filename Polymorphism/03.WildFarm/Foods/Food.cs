using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Foods
{
	public abstract class Food
	{
		public Food(int quantity)
		{
			Quantity = quantity;
		}

		public int Quantity
		{
			get;
			set;
		}
	}
}
