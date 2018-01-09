using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Exercise_1.Models
{
    public class Food
    {
        public string FoodName { get; set; }
        public string FoodCost { get; set; }
        public string ImageString { get; set; }

        public Food(string foodName, string foodCost, string imageString)
        {
            FoodName = foodName;
            FoodCost = foodCost;
            ImageString = imageString;
        }
    }
}