using System;
using System.Collections.Generic;

namespace PROG6221_POE_Part1
{
    public class Recipe
    {
        public string Name { get; private set; }
        private List<Ingredient> ingredients;
        private List<string> steps;

        public Recipe(string name)
        {
            Name = name;
            ingredients = new List<Ingredient>();
            steps = new List<string>();
        }

        public void EnterDetails()
        {
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = GetValidIntInput();

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter details for ingredient #{i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity = GetValidDoubleInput();
                Console.Write("Unit of measurement: ");
                string unit = Console.ReadLine();
                Console.Write("Calories: ");
                double calories = GetValidDoubleInput();
                Console.Write("Food Group: ");
                string foodGroup = Console.ReadLine();

                ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
            }

            Console.Write("\nEnter the number of steps: ");
            int numSteps = GetValidIntInput();

            Console.WriteLine("");

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                steps.Add(Console.ReadLine());
            }
        }

        public void Display()
        {
            Console.WriteLine($"\nRecipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }

        public void Scale(double factor)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Scale(factor);
            }
        }

        public void Reset()
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Reset();
            }
        }

        private int GetValidIntInput()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
        }

        private double GetValidDoubleInput()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
    }
}
