using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Drinks.RyanW84.Models;

using Newtonsoft.Json;

using RestSharp;

namespace Drinks.RyanW84;

public class DrinksService
{
    public List<Category> GetCategories( )
    {
    var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
    var request = new RestRequest("list.php?c=list");
    var response = client.ExecuteAsync(request);

    List<Category> categories = new();

    if(response.Result.StatusCode == System.Net.HttpStatusCode.OK)
    {
    string rawResponse = response.Result.Content;
    var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

    categories = serialize.CategoriesList;

    TableVisualisationEngine.ShowTable(categories , "Categories Menu");
    return categories;
    }
    return categories;
    }

    internal List<DrinksList> GetDrinksByCategory(string category)
    {
    var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1");
    var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
    var response = client.ExecuteAsync(request);

    List<DrinksList> drinks = new();

    if(response.Result.StatusCode == System.Net.HttpStatusCode.OK)
    {
    string rawResponse = response.Result.Content;

    var serialize = JsonConvert.DeserializeObject<DrinksResponse>(rawResponse);

    drinks = serialize.Drinks;

    TableVisualisationEngine.ShowTable(drinks , "Drinks Menu");
    return drinks;
    }

    return drinks;
    }

    public class DrinksResponse
    {
        [JsonProperty("drinks")]
        public List<DrinksList> Drinks { get; set; }
    }

    internal void GetDrink(string drink)
    {
    var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
    var request = new RestRequest($"lookup.php?i={drink}");
    var response = client.ExecuteAsync(request);

    if(response.Result.StatusCode == System.Net.HttpStatusCode.OK)
    {
    string rawResponse = response.Result.Content;

    var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

    List<DrinkDetail> returnedList = serialize.DrinkDetailList;

    DrinkDetail drinkDetail = returnedList[0];
    List<object> prepList = new(); //Anonymous object
    string formattedName = ""; //Empty string for outputting result

    foreach(PropertyInfo prop in drinkDetail.GetType().GetProperties())
    {
    if(prop.Name.Contains("str"))
    {
    formattedName = prop.Name.Substring(3); // Starting 3 chars along

    if(!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
    {
    prepList.Add(new
    {
        Key = formattedName ,
        Value = prop.GetValue(drinkDetail)
    });
    }
    }
    TableVisualisationEngine.ShowTable(prepList , drinkDetail.strDrink);
    }
    }
    }
}



