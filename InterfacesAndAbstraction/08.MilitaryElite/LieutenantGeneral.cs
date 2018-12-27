using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contracts
{
	public class LieutenantGeneral : Private, ILieutantGeneral
	{
		private ICollection<ISoldier> privates;

		public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
			: base(id, firstName, lastName, salary)
		{
			privates = new List<ISoldier>();
		}

		public IReadOnlyCollection<ISoldier> Privates => (IReadOnlyCollection<ISoldier>)privates;



		public void AddPrivate(ISoldier solider)

		{

			privates.Add(solider);

		}



		public override string ToString()

		{

			StringBuilder builder = new StringBuilder();

			builder.AppendLine(base.ToString())

				.AppendLine($"{nameof(Privates)}: ");

			foreach (ISoldier priv in Privates)

			{

				builder.AppendLine($"  {priv.ToString()}");

			}



			string result = builder.ToString().TrimEnd();

			return result;

		}

	}
}
