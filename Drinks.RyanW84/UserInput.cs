using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Drinks.RyanW84.Models;

namespace Drinks.RyanW84;

public class UserInput 
    {
    DrinksService drinksService = new();

    internal void GetCategoriesInput()
        {
        var categories =drinksService.GetCategories();

        Console.WriteLine("Choose Category:");

        string category = Console.ReadLine();

        while (!Validator.IsStringValid(category))
            {
            Console.WriteLine("Invalid Category");
            category = Console.ReadLine();
            }

            if (!categories.Any(x => x.strCategory == category))
            {
            Console.WriteLine("Category doesn't exist.");
            GetCategoriesInput();
            }

            GetDrinksInput(category);
        }

    private void GetDrinksInput(string category)
        {
        var drinks = drinksService.GetDrinksByCategory(category);
        drinksService.GetDrinksByCategory(category);

        Console.WriteLine("Choose a drink or got back to Categories by typing 0:");

        string drink = Console.ReadLine();

        if (drink == "0")
            GetCategoriesInput();

        while (!Validator.IsIDValid(drink))
            {
            Console.WriteLine("Invalid drink");
            drink = Console.ReadLine();
            }

        if (!drinks.Any(x => x.idDrink == drink))
            {
            Console.WriteLine("Drink doesn't Exist");
            GetDrinksInput(category);
            }
        }
    }

