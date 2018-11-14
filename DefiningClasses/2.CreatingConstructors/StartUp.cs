using System;

namespace DefiningClasses
{
	public class StartUp
	{
		static void Main(string[] args)
		{
			Person first = new Person();
			Person second = new Person();
			Person third = new Person();

			int secondAge = 20;
			string thirdName = "Petranka";
			int thirdAge = 16;

			Console.WriteLine(first.FirstPerson());
			Console.WriteLine(second.SecondPerson(secondAge));
			Console.WriteLine(third.ThirdPerson(thirdName, thirdAge));
		}
	}
}
