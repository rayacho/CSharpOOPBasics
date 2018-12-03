using System;

namespace _4.OnlineRadioDatabase
{
	public class Song
	{
		private const int ArtistMinLength = 3;
		private const int ArtistMaxLength = 20;
		private const int NameMinLength = 3;
		private const int NameMaxLength = 30;
		private const int MinutesMin = 0;
		private const int MinutesMax = 14;
		private const int SecondsMin = 0;
		private const int SecondsMax = 59;

		private string artistName;
		private string songName;
		private int minutes;
		private int seconds;

		public Song(string artist, string name, int minutes, int seconds)
		{
			ArtistName = artist;
			SongName = name;
			Minutes = minutes;
			Seconds = seconds;
		}

		private string ArtistName
		{
			set
			{
				if (value.Length < ArtistMinLength || value.Length > ArtistMaxLength)
				{
					throw new InvalidArtistNameException(ArtistMinLength, ArtistMaxLength);
				}

				artistName = value;
			}
		}

		private string SongName
		{
			set
			{
				if (value.Length < NameMinLength || value.Length > NameMaxLength)
				{
					throw new InvalidSongNameException(NameMinLength, NameMaxLength);
				}

				songName = value;
			}
		}

		public int Minutes
		{
			get
			{
				return minutes;
			}

			private set
			{
				if (value < MinutesMin || value > MinutesMax)
				{
					throw new InvalidSongMinutesException(MinutesMin, MinutesMax);
				}

				minutes = value;
			}
		}

		public int Seconds
		{
			get
			{
				return this.seconds;
			}

			private set
			{
				if (value < SecondsMin || value > SecondsMax)
				{
					throw new InvalidSongSecondsException(SecondsMin, SecondsMax);
				}

				this.seconds = value;
			}
		}
	}
}
