using System;
using System.Runtime.Serialization;

namespace _4.OnlineRadioDatabase
{
	internal class InvalidArtistNameException : InvalidSongException
	{
		private int artistMinLength;
		private int artistMaxLength;

		public InvalidArtistNameException() : base()
		{
		}

		public InvalidArtistNameException(string message) : base(message)
		{
		}

		public InvalidArtistNameException(int minNameLength, int maxNameLength) 
			: base($"Artist name should be between {minNameLength} and {maxNameLength} symbols.")
		{
		}
	}
}