﻿using System;
using System.Globalization;

namespace _5.DateModifier
{
	public class StartUp
	{
		static void Main(string[] args)
		{
			var firstDate = Console.ReadLine();
			var secondDate = Console.ReadLine();
			Console.WriteLine(DateModifier.GetDaysBetweenDates(firstDate, secondDate));
		}	
	}
}
