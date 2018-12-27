using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contracts
{
	public interface ISoldier
	{
		int Id
		{
			get;
		}

		string FirstName
		{
			get;
		}

		string LastName
		{
			get;
		}
	}
}
