using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks.RyanW84;

public class UserInput //10:05
    {
    DrinksService drinksService = new();

    internal void GetCategoriesInput()
        {
        drinksService.GetCategories();

        Console.WriteLine("Choose Category:");

        string category = Console.ReadLine();

        while (!Validator.IsStringValid(category))
            {
            Console.WriteLine("Invalid Category");
            category = Console.ReadLine();
            }
        }
    }

