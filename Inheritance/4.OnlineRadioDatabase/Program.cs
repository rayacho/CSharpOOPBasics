using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.OnlineRadioDatabase
{
	class Program
	{
		public static void Main(string[] args)
		{
			Stack<Song> songs = GetSongs();
			PrintPlaylistSummary(songs);
		}

		private static void PrintPlaylistSummary(Stack<Song> playlist)
		{
			Console.WriteLine($"Songs added: {playlist.Count}");

			int totalSeconds = playlist.Select(s => s.Seconds).Sum();
			int secondsToMinutes = totalSeconds / 60;
			int seconds = totalSeconds % 60;
			int totalMinutes = playlist.Select(s => s.Minutes).Sum() + secondsToMinutes;
			int minutesToHours = totalMinutes / 60;
			int minutes = totalMinutes % 60;
			int hours = minutesToHours;
			Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");
		}

		private static Stack<Song> GetSongs()
		{ 
			int numberOfSongs = int.Parse(Console.ReadLine());
			Stack<Song> songs = new Stack<Song>(numberOfSongs);

			while (numberOfSongs > 0)
			{
				var songDetails = Console.ReadLine().Split(';');

				try
				{
					var indexOfMinuteSecondSeparation = songDetails[2].IndexOf(':');

					if (songDetails.Length < 3 || indexOfMinuteSecondSeparation < 1 ||
						indexOfMinuteSecondSeparation > songDetails[2].Length - 2)
					{
						throw new InvalidSongException();
					}

					var artist = songDetails[0];
					var songName = songDetails[1];
					var minutes = int.Parse(songDetails[2].Substring(0, indexOfMinuteSecondSeparation));
					var seconds = int.Parse(songDetails[2].Substring(indexOfMinuteSecondSeparation + 1));

					songs.Push(new Song(artist, songName, minutes, seconds));
					Console.WriteLine("Song added.");
				}
				catch (InvalidSongException ise)
				{
					Console.WriteLine(ise.Message);
				}
				catch (FormatException fex)
				{
					Console.WriteLine("Invalid song length.");
				}

				numberOfSongs--;
			}

			return songs;
		}
	}
}
