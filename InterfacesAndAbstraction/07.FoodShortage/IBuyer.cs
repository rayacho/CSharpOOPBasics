using System;
using System.Collections.Generic;
using System.Text;

namespace _07.FoodShortage
{
	interface IBuyer : IHuman
	{
		int Food
		{
			get;
		}

		void BuyFood();
	}
}
