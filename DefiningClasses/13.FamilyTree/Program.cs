using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.FamilyTree
{
	class Program
	{
		static void Main(string[] args)
		{
			var familyTree = new List<Person>();
			string personInput = Console.ReadLine();
			Person mainPerson = new Person();

			if (IsBirthday(personInput))
			{
				mainPerson.Birthday = personInput;
			}
			else
			{
				mainPerson.FullName = personInput;
			}

			familyTree.Add(mainPerson);
			string command;

			while ((command = Console.ReadLine()) != "End")
			{
				string[] tokens = command.Split(" - ");

				if (tokens.Length > 1)
				{
					string firstPerson = tokens[0];
					string secondPesron = tokens[1];
					Person currentPerson;

					if (IsBirthday(firstPerson))
					{
						currentPerson = familyTree.FirstOrDefault(p => p.Birthday == firstPerson);

						if (currentPerson == null)
						{
							currentPerson = new Person();
							currentPerson.Birthday = firstPerson;
							familyTree.Add(currentPerson);
						}

						SetChild(familyTree, currentPerson, secondPesron);
					}
					else
					{
						currentPerson = familyTree.FirstOrDefault(p => p.FullName == firstPerson);

						if (currentPerson == null)
						{
							currentPerson = new Person();
							currentPerson.FullName = firstPerson;
							familyTree.Add(currentPerson);
						}

						SetChild(familyTree, currentPerson, secondPesron);
					}
				}
				else
				{
					tokens = tokens[0].Split();
					string name = $"{tokens[0]} {tokens[1]}";
					string birthday = tokens[2];
					Person person = familyTree.FirstOrDefault(p => p.FullName == name || p.Birthday == birthday);

					if (person == null)
					{
						person = new Person();
						familyTree.Add(person);
					}

					person.FullName = name;
					person.Birthday = birthday;

					int index = familyTree.IndexOf(person) + 1;
					int count = familyTree.Count - index;

					Person[] copy = new Person[count];
					familyTree.CopyTo(index, copy, 0, count);

					Person copyPerson = copy.FirstOrDefault(p => p.FullName == name || p.Birthday == birthday);

					if (copyPerson != null)
					{
						familyTree.Remove(copyPerson);
						person.Parents.AddRange(copyPerson.Parents);
						person.Parents = person.Parents.Distinct().ToList();
						foreach (var parent in copyPerson.Parents)
						{
							int copyPersonIndex = parent.Children.IndexOf(copyPerson);
							if(copyPersonIndex > -1)
							{
								parent.Children[copyPersonIndex] = person;
							}
							else
							{
								parent.Children.Add(person);
							}
						}

						person.Children.AddRange(copyPerson.Children);
						person.Children = person.Children.Distinct().ToList();
						foreach (var child in copyPerson.Children)
						{
							int copyPersonIndex = child.Parents.IndexOf(copyPerson);
							if (copyPersonIndex > -1)
							{
								child.Parents[copyPersonIndex] = person;
							}
							else
							{
								child.Parents.Add(person);
							}
						}
					}
				}
			}

			Console.WriteLine(mainPerson);

			Console.WriteLine("Parents:");
			foreach (var p in mainPerson.Parents)
			{
				Console.WriteLine(p);
			}

			Console.WriteLine("Children:");
			foreach (var c in mainPerson.Children)
			{
				Console.WriteLine(c);
			}
		}

		private static void SetChild(List<Person> familyTree, Person parentPerson, string child)
		{
			Person childPerson = new Person();

			if (IsBirthday(child))
			{
				if (!familyTree.Any(p => p.Birthday == child))
				{
					childPerson.Birthday = child;
				}
				else			
				{
					childPerson = familyTree.First(p => p.Birthday == child);
					familyTree.Add(childPerson);
				}
			}
			else
			{
				if (!familyTree.Any(p => p.FullName == child))
				{
					childPerson.FullName = child;
				}
				else
				{
					childPerson = familyTree.First(p => p.FullName == child);
					familyTree.Add(childPerson);
				}
			}

			parentPerson.Children.Add(childPerson);
			parentPerson.Parents.Add(parentPerson);	
		}

		static bool IsBirthday(string input)
		{
			return Char.IsDigit(input[0]);
		}
	}
}
	
