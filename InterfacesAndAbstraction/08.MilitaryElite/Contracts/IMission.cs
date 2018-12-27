using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contracts
{
	public interface IMission
	{
		string CodeName
		{
			get;
		}

		MissionState State
		{
			get;
		}

		void Complete();
	}
}
