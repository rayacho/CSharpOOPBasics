using _03.WildFarm.Animals;
using _03.WildFarm.Animals.Type;
using _03.WildFarm.Foods;
using System;
using System.Collections.Generic;

namespace _03.WildFarm
{
	class StartUp
	{
		static void Main(string[] args)
		{
			List<Animal> animals = new List<Animal>();
			string input;

			while ((input = Console.ReadLine()) != "End")
			{
				Animal animal = ParseAnimal(input);
				animals.Add(animal);
				string[] foodTokens = Console.ReadLine().Split();
				Food food = ParseFood(foodTokens);
				Console.WriteLine(animal.MakeSound());

				try
				{
					animal.TryEatFood(food);
				}
				catch (InvalidOperationException e)
				{
					Console.WriteLine(e.Message);
				}
			}

			foreach (Animal animal in animals)
			{
				Console.WriteLine(animal);
			}
		}

		private static Food ParseFood(string[] foodTokens)
		{
			string foodType = foodTokens[0];
			int quantity = int.Parse(foodTokens[1]);
			Food food = null;

			switch (foodType)
			{
				case "Meat":
					food = new Meat(quantity);
					break;

				case "Vegetable":
					food = new Vegetable(quantity);
					break;

				case "Fruit":
					food = new Fruit(quantity);
					break;

				case "Seeds":
					food = new Seeds(quantity);
					break;

				default:
					throw new ArgumentException("Invalid type of food!");
			}

			return food;
		}

		private static Animal ParseAnimal(string input)
		{
			string[] animalTokens = input.Split();
			string animalType = animalTokens[0];
			string name = animalTokens[1];
			double weight = double.Parse(animalTokens[2]);
			string thirdToken = animalTokens[3];
			Animal animal = null;

			switch (animalType)
			{
				case "Cat":
					string catBreed = animalTokens[4];
					animal = new Cat(name, weight, thirdToken, catBreed);
					break;

				case "Tiger":

					string tigerBreed = animalTokens[4];
					animal = new Tiger(name, weight, thirdToken, tigerBreed);
					break;

				case "Dog":
					animal = new Dog(name, weight, thirdToken);
					break;

				case "Mouse":
					animal = new Mouse(name, weight, thirdToken);
					break;

				case "Owl":
					double owlWingSize = double.Parse(thirdToken);
					animal = new Owl(name, weight, owlWingSize);
					break;

				case "Hen":
					double henWingSize = double.Parse(thirdToken);
					animal = new Hen(name, weight, henWingSize);
					break;

				default:
					throw new ArgumentException("Invalid animal type!");
			}

			return animal;
		}
	}
}
