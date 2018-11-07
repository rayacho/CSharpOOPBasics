using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _3.OldestFamilyMember
{
	public class Family
	{
		private List<Person> people;

		public Family()
		{
			people = new List<Person>();
		}

		public List<Person> People
		{
			get { return people; }
			set { people = value; }
		}

		public void AddMember(Person member)
		{
			people.Add(member);
		}

		public Person GetOldestMember()
		{
			return people.OrderByDescending(m => m.Age).FirstOrDefault();
		}
	}
}
