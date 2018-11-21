﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.GreedyTimes
{
	public class Program
	{
		static void Main(string[] args)
		{
			long bagCapacity = long.Parse(Console.ReadLine());
			string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			var bag = new Dictionary<string, Dictionary<string, long>>();
			long gold = 0;
			long gem = 0;
			long cash = 0;

			for (int i = 0; i < input.Length; i += 2)
			{
				string name = input[i];
				long count = long.Parse(input[i + 1]);

				string type = string.Empty;

				if (name.Length == 3)
				{
					type = "Cash";
				}
				else if (name.ToLower().EndsWith("gem"))
				{
					type = "Gem";
				}
				else if (name.ToLower() == "gold")
				{
					type = "Gold";
				}

				if (type == "")
				{
					continue;
				}
				else if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + count)
				{
					continue;
				}

				switch (type)
				{
					case "Gem":
						if (!bag.ContainsKey(type))
						{
							if (bag.ContainsKey("Gold"))
							{
								if (count > bag["Gold"].Values.Sum())
								{
									continue;
								}
							}
							else
							{
								continue;
							}
						}
						else if (bag[type].Values.Sum() + count > bag["Gold"].Values.Sum())
						{
							continue;
						}
						break;
					case "Cash":
						if (!bag.ContainsKey(type))
						{
							if (bag.ContainsKey("Gem"))
							{
								if (count > bag["Gem"].Values.Sum())
								{
									continue;
								}
							}
							else
							{
								continue;
							}
						}
						else if (bag[type].Values.Sum() + count > bag["Gem"].Values.Sum())
						{
							continue;
						}
						break;
				}

				if (!bag.ContainsKey(type))
				{
					bag[type] = new Dictionary<string, long>();
				}

				if (!bag[type].ContainsKey(name))
				{
					bag[type][name] = 0;
				}

				bag[type][name] += count;
				if (type == "Gold")
				{
					gold += count;
				}
				else if (type == "Gem")
				{
					gem += count;
				}
				else if (type == "Cash")
				{
					cash += count;
				}
			}

			foreach (var x in bag)
			{
				Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
				foreach (var item in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
				{
					Console.WriteLine($"##{item.Key} - {item.Value}");
				}
			}
		}
	}
}
