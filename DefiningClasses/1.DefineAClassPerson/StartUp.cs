﻿using System;

namespace DefiningClasses
{
	public class StartUp
	{
		static void Main(string[] args)
		{
			Person first = new Person();
			first.Name = "Gosho";
			first.Age = 13;
			var result = first.NameAndAge();
			Console.WriteLine(result);
		}
	}
}