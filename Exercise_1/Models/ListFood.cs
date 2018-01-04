using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Newtonsoft.Json;

namespace Exercise_1.Models
{
    
    public class ListFood
    {
        private readonly List<Food> foods;

        public ListFood()
        {
            foods = BuildInFoods;
        }

        private static readonly List<Food> BuildInFoods = new List<Food>()
        {
            new Food("Hamburger", "10$", "iamge"),
            new Food("Chicken", "20$", "iamge")
        };
        public int NumOfFoods => foods.Count;
        public Food this[int i] => foods[i];
    }

}