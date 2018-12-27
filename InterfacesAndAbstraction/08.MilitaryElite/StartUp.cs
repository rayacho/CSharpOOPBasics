using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.MilitaryElite.Contracts
{
	class StartUp
	{
		static void Main(string[] args)
		{
			List<ISoldier> soldiers = new List<ISoldier>();
			string input;

			while ((input = Console.ReadLine()) != "End")
			{
				string[] tokens = input.Split();
				string soldierType = tokens[0];
				int id = int.Parse(tokens[1]);
				string firstName = tokens[2];
				string lastName = tokens[3];
				decimal salary = decimal.Parse(tokens[4]);
				ISoldier soldier = null;

				try
				{
					switch (soldierType)
					{
						case "Private":
							soldier = new Private(id, firstName, lastName, salary);
							break;
						case "LieutenantGeneral":
							LieutenantGeneral lieutant = new LieutenantGeneral(id, firstName, lastName, salary);

							for (int i = 5; i < tokens.Length; i++)
							{
								int privaId = int.Parse(tokens[i]);
								ISoldier priva = soldiers.First(p => p.Id == privaId);
								lieutant.AddPrivate(priva);
							}

							soldier = lieutant;
							break;

						case "Engineer":
							string engineerCorps = tokens[5];
							Engineer engineer = new Engineer(id, firstName, lastName, salary, engineerCorps);

							for (int i = 6; i < tokens.Length; i++)
							{
								string partName = tokens[i];
								int hoursWorked = int.Parse(tokens[++i]);
								IRepair repair = new Repair(partName, hoursWorked);
								engineer.AddRepair(repair);
							}

							soldier = engineer;
							break;

						case "Commando":
							string commandoCorps = tokens[5];
							Commando commando = new Commando(id, firstName, lastName, salary, commandoCorps);

							for (int i = 6; i < tokens.Length; i++)
							{
								string codeName = tokens[i];
								string missionState = tokens[++i];

								try
								{
									IMission mission = new Mission(codeName, missionState);
									commando.AddMission(mission);
								}
								catch
								{
								}
							}

							soldier = commando;
							break;

						case "Spy":
							int codeNumber = (int)salary;
							soldier = new Spy(id, firstName, lastName, codeNumber);
							break;

						default:
							throw new ArgumentException("Invalid soldier type!");
					}

					soldiers.Add(soldier);
				}

				catch 
				{
				}
			}

			foreach (ISoldier s in soldiers)
			{
				Console.WriteLine(s);
			}
		}
	}
}