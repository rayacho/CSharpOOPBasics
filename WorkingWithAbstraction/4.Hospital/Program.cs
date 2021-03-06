﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
	public class Program
	{
		public static void Main()
		{
			Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
			Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

			string command = Console.ReadLine();
			while (command != "Output")
			{
				string[] tokens = command.Split();
				string department = tokens[0];
				string firstName = tokens[1];
				string secondName = tokens[2];
				string patient = tokens[3];
				string fullName = firstName + secondName;

				if (!doctors.ContainsKey(firstName + secondName))
				{
					doctors[fullName] = new List<string>();
				}

				if (!departments.ContainsKey(department))
				{
					departments[department] = new List<List<string>>();
					for (int rooms = 0; rooms < 20; rooms++)
					{
						departments[department].Add(new List<string>());
					}
				}

				bool isAvailable = departments[department].SelectMany(x => x).Count() < 60;
				if (isAvailable)
				{
					int room = 0;
					doctors[fullName].Add(patient);
					for (int st = 0; st < departments[department].Count; st++)
					{
						if (departments[department][st].Count < 3)
						{
							room = st;
							break;
						}
					}
					departments[department][room].Add(patient);
				}

				command = Console.ReadLine();
			}

			command = Console.ReadLine();

			while (command != "End")
			{
				string[] args = command.Split();

				if (args.Length == 1)
				{
					Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
				}
				else if (args.Length == 2 && int.TryParse(args[1], out int staq))
				{
					Console.WriteLine(string.Join("\n", departments[args[0]][staq - 1].OrderBy(x => x)));
				}
				else
				{
					Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
				}
				command = Console.ReadLine();
			}
		}
	}
}
