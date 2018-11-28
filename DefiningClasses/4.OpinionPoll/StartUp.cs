using DefiningClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.OpinionPoll
{
	class StartUp
	{
		static void Main(string[] args)
		{
			HashSet<Person> people = GetPeople();
			PrintPeopleOlderThan30(people);
		}

		private static void PrintPeopleOlderThan30(HashSet<Person> people)
		{
			IEnumerable<string> peoples = people
				.Where(p => p.Age > 30)
				.OrderBy(p => p.Name)
				.Select(p => $"{p.Name} - {p.Age}");

			string print = string.Join(Environment.NewLine, peoples);

			Console.WriteLine(print);
		}

		private static HashSet<Person> GetPeople()
		{
			var people = new HashSet<Person>();
			int numberOfPeople = int.Parse(Console.ReadLine());

			while (numberOfPeople > 0)
			{
				string[] personData = Console.ReadLine().Split();
				string name = personData[0];
				int age = int.Parse(personData[1]);
				var person = new Person(name, age);
				people.Add(person);
				numberOfPeople--;
			}

			return people;
		}
	}
}
