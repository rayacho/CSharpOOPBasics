using System;

namespace _04.Telephony
{
	class Program
	{
		public static void Main()
		{
			Smartphone phone = new Smartphone("Smartphone");

			TestPhone(phone);
		}

		private static void TestPhone(ICalling phone)
		{
			string[] numbersToCall = Console.ReadLine().Split();

			foreach (string number in numbersToCall)
			{
				Console.WriteLine(phone.Call(number));
			}

			string[] sitesToBrowse = Console.ReadLine().Split();

			foreach (string site in sitesToBrowse)
			{
				Console.WriteLine(phone.Call(site));
			}
		}
	}
}
