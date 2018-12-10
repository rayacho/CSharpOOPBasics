using System;
using System.Collections.Generic;
using System.Text;

namespace _02.MultipleImplementation
{
	public interface IPerson : IBirthable
	{
		string Name { get; }

		int Age { get; }
	}
}
