using System;
using System.Collections.Generic;
using System.Text;

namespace _02.MultipleImplementation
{
	public interface IBirthable : IIdentifiable
	{
		string Birthdate { get; }
	}
}
