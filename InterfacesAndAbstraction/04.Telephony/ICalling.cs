using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Telephony
{
	public interface ICalling : IPhone
	{
		string Browse(string url);
	}
}
