using System;
using System.Runtime.Serialization;

namespace _4.OnlineRadioDatabase
{
	[Serializable]
	internal class InvalidSongNameException : InvalidSongException
	{
		private int nameMinLength;
		private int nameMaxLength;

		public InvalidSongNameException() : base()
		{
		}

		public InvalidSongNameException(string message) : base(message)
		{
		}

		public InvalidSongNameException(int minNameLength, int maxNameLength)
			: base($"Song name should be between {minNameLength} and {maxNameLength} symbols.")
		{
		}
		
	}
}