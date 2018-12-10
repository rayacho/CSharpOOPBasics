using System;
using System.Globalization;

namespace _5.DateModifier
{
	class DateModifier
	{
		public static double GetDaysBetweenDates(string dateOne, string dateTwo)
		{
			if (string.IsNullOrEmpty(dateOne))
			{
				throw new ArgumentNullException(nameof(dateOne));
			}

			if (string.IsNullOrEmpty(dateTwo))
			{
				throw new ArgumentNullException(nameof(dateTwo));
			}

			DateTime firstDate = DateTime.ParseExact(dateOne, "yyyy MM dd", CultureInfo.InvariantCulture);
			DateTime secondDate = DateTime.ParseExact(dateTwo, "yyyy MM dd", CultureInfo.InvariantCulture);

			double result;
			if (firstDate > secondDate)
			{
				result = GetDaysBetweenDates(dateTwo, dateOne);
				return result;
			}

			result = (secondDate - firstDate).Days;

			return result;
		}
	}
}
