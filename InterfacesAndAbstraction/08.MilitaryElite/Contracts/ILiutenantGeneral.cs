using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contracts
{
	public interface ILieutantGeneral
	{
		IReadOnlyCollection<ISoldier> Privates
		{
			get;
		}

		void AddPrivate(ISoldier solider);
	}
}
