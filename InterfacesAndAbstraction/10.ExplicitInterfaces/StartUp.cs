using System;
using System.Collections.Generic;

namespace _10.ExplicitInterfaces
{
	class StartUp
	{
		static void Main(string[] args)
		{
			List<Human> human = new List<Human>();
			string input = Console.ReadLine();

			while (input != "End")
			{
				string[] inputParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				Human citizen = new Human(inputParts[0], inputParts[1], int.Parse(inputParts[2]));
				human.Add(citizen);
				input = Console.ReadLine();
			}

			foreach (Human h in human)
			{
				IPerson person = h;
				IResident resident = h;

				person.GetName();
				resident.GetName();
			}
		}
	}
}
