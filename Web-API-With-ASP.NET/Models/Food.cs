using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAPI.Models
{
    public class Food
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string image2 { get; set; }
        public string youtubevideo { get; set; }
        public string description { get; set; }
        public string shortDescription { get; set; }
        public bool isPopular { get; set; }
        public string country { get; set; }
        public string addedBy { get; set; }
        public string title { get; set; }
        public bool isNew { get; set; }
        public string type { get; set; }
        public int peopleNumber { get; set; }
        public int cookingTime { get; set; }
        public int kalori { get; set; }
        public int protein { get; set; }
        public int karbonhidrat { get; set; }
        public int yağ { get; set; }

        /********ingredients*********/
        public string ingredient1 { get; set; }
        public string ingredient2 { get; set; }
        public string ingredient3 { get; set; }
        public string ingredient4 { get; set; }
        public string ingredient5 { get; set; }
        public string ingredient6 { get; set; }
        public string ingredient7 { get; set; }
        public string ingredient8 { get; set; }
        public string ingredient9 { get; set; }
        public string ingredient10 { get; set; }
        public string ingredient11 { get; set; }
        public string ingredient12 { get; set; }
        public string ingredient13 { get; set; }
        public string ingredient14 { get; set; }
        public string ingredient15 { get; set; }
        public string ingredient16 { get; set; }


    }
}
