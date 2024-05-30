using PROG6221_POE_Part1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_Part1
{
    public enum FoodGroup
    {
        StarchyFoods = 1,
        VegetablesAndFruits,
        DryBeansPeasLentilsSoya,
        ChickenFishMeatEggs,
        MilkAndDairyProducts,
        FatsAndOil,
        Water
    }
    internal class RecipeManager
    {
        private List<Recipe> recipes;
        public delegate void CalorieNotification(string message);
        public event CalorieNotification OnHighCalories;

        public RecipeManager()
        {
            recipes = new List<Recipe>();
            OnHighCalories += NotifyHighCalories;
        }

        // Method to add a new recipe
        public void AddRecipe()
        {
            Console.Write("\nEnter the name of the recipe: ");
            string name = Console.ReadLine();

            Recipe recipe = new Recipe(name);

            recipe.EnterDetails();

            recipes.Add(recipe);
            recipes = recipes.OrderBy(r => r.Name).ToList(); // Sort recipes alphabetically by name
        }

        // Method to display all recipes
        public void DisplayAllRecipes()
        {
            Console.WriteLine("\nList of Recipes:");
            foreach (var recipe in recipes)
            {
                Console.WriteLine(recipe.Name);
            }
        }

        // Method to display a specific recipe
        public void DisplayRecipe()
        {
            Console.Write("Enter the name of the recipe to display: ");
            string name = Console.ReadLine();

            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                recipe.Display();
                double totalCalories = recipe.CalculateTotalCalories();
                Console.WriteLine($"Total Calories: {totalCalories}");

                if (totalCalories > 300)
                {
                    OnHighCalories?.Invoke($"Warning: The total calories for the recipe '{recipe.Name}' exceed 300!");
                }
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Method to scale a specific recipe
        public void ScaleRecipe()
        {
            Console.Write("Enter the name of the recipe to scale: ");
            string name = Console.ReadLine();

            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                Console.Write("Enter scaling factor ('0.5' for half, '2' for double, and '3' for triple): ");
                if (double.TryParse(Console.ReadLine(), out double factor))
                {
                    recipe.Scale(factor);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value for scaling factor.");
                }
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Method to reset quantities of a specific recipe
        public void ResetRecipe()
        {
            Console.Write("Enter the name of the recipe to reset: ");
            string name = Console.ReadLine();

            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                recipe.Reset();
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Method to clear all recipes
        public void ClearAllRecipes()
        {
            recipes.Clear();
            Console.WriteLine("All recipes have been cleared.");
        }

        // Method to notify when a recipe exceeds 300 calories
        private void NotifyHighCalories(string message)
        {
            Console.WriteLine(message);
        }
    }
}

