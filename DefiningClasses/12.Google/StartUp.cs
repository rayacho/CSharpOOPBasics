using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Google
{
	public class StartUp
	{
		static void Main(string[] args)
		{
			Queue<Person> collectedData = CollectData();

			PrintPerson(collectedData);
		}

		private static void PrintPerson(Queue<Person> collectedData)
		{
			string personToPrint = Console.ReadLine();
			Person person = collectedData.FirstOrDefault(p => p.Name == personToPrint);

			if (person != null)
			{
				Console.Write(person.ToString());
			}
		}

		private static Queue<Person> CollectData()
		{
			Queue<Person> collectedData = new Queue<Person>();
			string[] data = Console.ReadLine().Split();

			while (data[0] != "End")
			{
				string personName = data[0];
				Person currentPerson = collectedData.FirstOrDefault(p => p.Name == personName);

				if (currentPerson == null)
				{
					currentPerson = new Person(personName);
					collectedData.Enqueue(currentPerson);
				}

				OrderData(currentPerson, data);

				data = Console.ReadLine().Split();
			}

			return collectedData;
		}

		private static void OrderData(Person currentPerson, string[] data)
		{
			switch (data[1])
			{
				case "company":
					string companyName = data[2];
					decimal salary = decimal.Parse(data[4]);
					string department = data[3];
					currentPerson.AssignACompany(new Company(companyName, salary, department));
					break;

				case "pokemon":
					string pokemonName = data[2];
					string type = data[3];
					currentPerson.AddInCollection(new Pokemon(pokemonName, type));
					break;

				case "parents":
					string parentName = data[2];
					string parentBirthDay = data[3];
					currentPerson.AddInCollection(new Parent(parentName, parentBirthDay));
					break;

				case "children":
					string childName = data[2];
					string childBirthDay = data[3];
					currentPerson.AddInCollection(new Child(childName, childBirthDay));
					break;

				case "car":
					string model = data[2];
					int speed = int.Parse(data[3]);
					currentPerson.AssignACar(new Car(model, speed));
					break;
				default:
					break;
			}
		}
	}
}
