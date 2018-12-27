using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contracts
{
	public class Private : Soldier, IPrivate
	{
		public Private(int id, string firstName, string lastName, decimal salary)
			: base(id, firstName, lastName)
		{
			Salary = salary;
		}

		public decimal Salary
		{
			get;
			private set;
		}

		public override string ToString()
		{
			return $"{base.ToString()} Salary: {Salary:f2}";
		}
	}
}
