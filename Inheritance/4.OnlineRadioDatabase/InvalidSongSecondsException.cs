using System;
using System.Runtime.Serialization;

namespace _4.OnlineRadioDatabase
{
	[Serializable]
	internal class InvalidSongSecondsException : InvalidSongLengthException
	{
		private int secondsMin;
		private int secondsMax;

		public InvalidSongSecondsException()
		{
		}

		public InvalidSongSecondsException(string message) : base(message)
		{
		}

		public InvalidSongSecondsException(int minSongSeconds, int maxSongSeconds)
			: base($"Song seconds should be between {minSongSeconds} and {maxSongSeconds}.")
		{
		}
	}
}