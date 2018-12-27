using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contracts
{
	interface ISpy : ISoldier
	{
		int CodeNumber
		{
			get;
		}
	}
}
