using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contracts
{
	interface ICommando : ISpecialisedSoldier
	{
		IReadOnlyCollection<IMission> Missions
		{
			get;
		}

		void AddMission(IMission mission);

		void CompleteMission(string missionCodeName);
	}
}
