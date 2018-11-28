using System;

namespace DefiningClasses
{
	public class StartUp
	{
		static void Main(string[] args)
		{
			var first = new Person
			{
				Name = "Gosho",
				Age = 13
			};

			string result = first.NameAndAge();
			Console.WriteLine(result);
		}
	}
}