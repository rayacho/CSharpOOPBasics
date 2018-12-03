using System;
using System.Runtime.Serialization;

namespace _4.OnlineRadioDatabase
{
	internal class InvalidSongMinutesException : InvalidSongLengthException
	{
		private int minutesMin;
		private int minutesMax;

		public InvalidSongMinutesException() : base()
		{
		}

		public InvalidSongMinutesException(string message) : base(message)
		{
		}

		public InvalidSongMinutesException(int minSongMinutes, int msxSongMinutes)
			: base($"Song minutes should be between {minSongMinutes} and {msxSongMinutes}.")
		{
		}
		
	}
}