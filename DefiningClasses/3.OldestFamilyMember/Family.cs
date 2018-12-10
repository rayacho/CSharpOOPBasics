using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _3.OldestFamilyMember
{
	public class Family
	{
		private List<Person> _people;

		public Family()
		{
			_people = new List<Person>();
		}

		public List<Person> People
		{
			get
			{
				return _people;
			}
			set
			{
				_people = value;
			}
		}

		public void AddMember(Person member)
		{
			if (member == null)
			{
				throw new ArgumentNullException(nameof(member));
			}

			_people.Add(member);
		}

		public Person GetOldestMember()
		{
			return _people.OrderByDescending(m => m.Age).FirstOrDefault();
		}
	}
}
