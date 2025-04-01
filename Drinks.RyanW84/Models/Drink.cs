using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Drinks.RyanW84.Models;

public class Drinks
    {
    [JsonProperty("drinks")]
    public List<DrinksList> DrinksList { get; set; }
    }

public class DrinksList
    {
    public string idDrink {  get; set; }
    public string strDrink { get; set; }
    }

