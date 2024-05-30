using PROG6221_POE_Part1;
using System;
using System.Collections.Generic;
using System.Linq;
// Create a new RecipeManager object to manage multiple recipes
RecipeManager recipeManager = new RecipeManager();
bool running = true;
string choice;

// Display welcome message
Console.WriteLine("----------------------------------------------\n"
                 + "Welcome to your personal recipe calculator app\n"
                 + "----------------------------------------------");

while (running)
{
    // Display menu options
    Console.WriteLine("\n");
    Console.WriteLine("1. Enter Recipe Details");
    Console.WriteLine("2. Display All Recipes");
    Console.WriteLine("3. Display a Recipe");
    Console.WriteLine("4. Scale Recipe");
    Console.WriteLine("5. Reset Quantities");
    Console.WriteLine("6. Clear All Data");
    Console.WriteLine("7. Exit");
    Console.WriteLine("\nChoose an option:");

    // Read user input for choice
    choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            // Enter new recipe details
            recipeManager.AddRecipe();
            break;
        case "2":
            // Display all recipes
            recipeManager.DisplayAllRecipes();
            break;
        case "3":
            // Display a specific recipe
            recipeManager.DisplayRecipe();
            break;
        case "4":
            // Scale a recipe
            recipeManager.ScaleRecipe();
            break;
        case "5":
            // Reset quantities of the recipe
            recipeManager.ResetRecipe();
            break;
        case "6":
            // Clear all data in the recipe
            recipeManager.ClearAllRecipes();
            break;
        case "7":
            // Exit the program
            running = false;
            break;
        default:
            // Inform user of invalid input
            Console.WriteLine("\nYou have entered an invalid choice.\nPlease try again");
            break;
    }
}