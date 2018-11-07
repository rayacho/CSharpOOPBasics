using System;
using System.Reflection;

namespace _3.OldestFamilyMember
{
	class Program
	{
		public static void Main(string[] args)
		{
			MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
			MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");

			if (oldestMemberMethod == null || addMemberMethod == null)
			{
				throw new Exception();
			}

			Family family = new Family();
			int membersNumber = int.Parse(Console.ReadLine());

			while (membersNumber > 0)
			{
				string[] personData = Console.ReadLine().Split();
				Person member = new Person(personData[0], int.Parse(personData[1]));
				family.AddMember(member);
				membersNumber--;
			}

			Person oldestMember = family.GetOldestMember();

			Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
		}
	}
}
