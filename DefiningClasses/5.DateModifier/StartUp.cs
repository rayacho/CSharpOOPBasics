﻿using System;

namespace _5.DateModifier
{
	public class StartUp
	{
		static void Main(string[] args)
		{
			string firstDate = Console.ReadLine();
			string secondDate = Console.ReadLine();
			double print = DateModifier.GetDaysBetweenDates(firstDate, secondDate);
			Console.WriteLine(print);
		}	
	}
}
