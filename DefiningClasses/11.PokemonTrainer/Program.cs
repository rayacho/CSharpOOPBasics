using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PokemonTrainer
{
	public class Program
	{
		private const int PokemonHealtLossDueToMissingElement = 10;

		public static void Main()
		{
			Queue<Trainer> trainers = GetTrainers();
			PlayWithElements(trainers);
			PrintTrainers(trainers);
		}

		private static void PrintTrainers(Queue<Trainer> trainers)
		{
			string result = string.Join(Environment.NewLine, trainers
				.OrderByDescending(t => t.Badges)
				.Select(t => $"{t.Name} {t.Badges} {t.Pokemons.Count}"));
			Console.WriteLine();
		}

		private static void PlayWithElements(Queue<Trainer> trainers)
		{
			string element = Console.ReadLine().Trim();

			while (element != "End")
			{
				foreach (Trainer trainer in trainers)
				{
					Pokemon first = trainer.Pokemons.Where(p => p.Element == element).FirstOrDefault();
					if (first == null)
					{
						foreach (Pokemon pokemon in trainer.Pokemons)
						{
							pokemon.ReduceHealth();
						}

						trainer.ClearDeadPokemons();
					}				
					else
					{
						trainer.AddABadge();
					}
				}

				element = Console.ReadLine().Trim();
			}
		}

		private static Queue<Trainer> GetTrainers()
		{
			var trainers = new Queue<Trainer>();
			string[] playerData = Console.ReadLine().Split().Select(x => x.Trim()).ToArray();

			while (playerData[0] != "Tournament")
			{
				string trainerName = playerData[0];
				string pokemonName = playerData[1];
				string element = playerData[2];
				int health = int.Parse(playerData[3]);
				Pokemon currentPokemon = new Pokemon(pokemonName, element, health);
				Trainer currentTrainer = trainers.Where(t => t.Name == trainerName).FirstOrDefault();

				if (currentTrainer == null)
				{
					currentTrainer = new Trainer(trainerName);
					currentTrainer.Pokemons.Push(currentPokemon);
					trainers.Enqueue(currentTrainer);
				}
				else
				{
					currentTrainer.Pokemons.Push(currentPokemon);
				}

				playerData = Console.ReadLine().Split().Select(x => x.Trim()).ToArray();
			}

			return trainers;
		}
	}
}
