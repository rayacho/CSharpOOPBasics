using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Ferrari
{
	public interface ICar
	{
		string Model { get; }

		string Driver { get; }

		string Brakes();

		string Gas();
	}
}
