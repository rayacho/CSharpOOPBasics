using System;
using System.Reflection;

namespace DefiningClasses
{
	public class StartUp
	{
		static void Main(string[] args)
		{
			string name = Console.ReadLine();
			int age = int.Parse(Console.ReadLine());

			Person person = new Person();
			Person personWithAge = new Person(age);
			Person personWithAgeAndName = new Person(name, age);

			Console.WriteLine("{0} {1}", person.Name, person.Age);
			Console.WriteLine("{0} {1}", personWithAge.Name, personWithAge.Age);
			Console.WriteLine("{0} {1}", personWithAgeAndName.Name, personWithAgeAndName.Age);
		}
	}
}
