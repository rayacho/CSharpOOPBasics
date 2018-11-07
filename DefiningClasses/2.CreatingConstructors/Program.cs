using System;
namespace _02.CreatingConstructors
{
	class Program
	{
		static void Main(string[] args)
		{
			int secondAge;
			string thirdName;
			int thirdAge;
			Person first = new Person();
			Person second = new Person();
			Person third = new Person();
			secondAge = 12;
			thirdName = "Gosho";
			thirdAge = 17;
			var firstPerson = first.FirstNameAndAge();
			var secondPerson = second.SecondNameAndAge(secondAge);
			var thirdPerson = third.ThirdNameAndAge(thirdName, thirdAge);

			Console.WriteLine(firstPerson);
			Console.WriteLine(secondPerson);
			Console.WriteLine(thirdPerson);
		}
	}
}
