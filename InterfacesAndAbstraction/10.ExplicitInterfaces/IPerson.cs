﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _10.ExplicitInterfaces
{
	public interface IPerson
	{
		string Name
		{
			get;
		}

		int Age
		{
			get;
		}

		void GetName();
	}
}
