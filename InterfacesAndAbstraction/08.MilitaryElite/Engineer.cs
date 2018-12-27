using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contracts
{
	class Engineer : SpecialisedSoldier, IEngineer
	{
		public Engineer(int id, string firstName, string lastName, decimal salary, string corps)
			: base(id, firstName, lastName, salary, corps)
		{
			repairs = new List<IRepair>();
		}

		private ICollection<IRepair> repairs;

		public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<IRepair>)repairs;

		public void AddRepair(IRepair repair)
		{
			repairs.Add(repair);
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine(base.ToString())
				.AppendLine($"{nameof(Corps)}: {Corps}")
				.AppendLine($"{nameof(Repairs)}:");

			foreach (IRepair repair in Repairs)
			{
				builder.AppendLine($"  {repair.ToString()}");
			}

			string result = builder.ToString().TrimEnd();
			return result;
		}
	}
}
