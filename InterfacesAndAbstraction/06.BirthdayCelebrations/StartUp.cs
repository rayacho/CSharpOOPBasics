using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.BirthdayCelebrations
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			List<IBirthdate> birthdates = new List<IBirthdate>();

			ParseInput(birthdates);

			string specificYear = Console.ReadLine();

			foreach (IBirthdate birthdate in birthdates.Where(b => b.Birthday.EndsWith(specificYear)))
			{
				Console.WriteLine(birthdate.Birthday);
			}
		}

		private static void ParseInput(List<IBirthdate> birthdates)
		{
			string input = Console.ReadLine();

			while (input != "End")
			{
				string[] inputParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				string type = inputParts[0];

				switch (type)
				{
					case "Citizen":
						IBirthdate citizen = new Human(inputParts[1], int.Parse(inputParts[2]),
							inputParts[3], inputParts[4]); birthdates.Add(citizen);
						break;
					case "Pet":
						IBirthdate pet = new Pet(inputParts[1], inputParts[2]);
						birthdates.Add(pet);
						break;
				}

				input = Console.ReadLine();
			}
		}
	}
}
