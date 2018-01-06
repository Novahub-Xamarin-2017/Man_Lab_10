using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Stream = Android.Media.Stream;

namespace Exercise_1.Models
{
    
    public class ListFood
    {
        private readonly List<Food> foods;

        public ListFood()
        {
            foods = ReadJson<Food>();
        }
        public List<T> ReadJson<T>()
        {
            var stream = Android.App.Application.Context.Assets.Open($"{typeof(T).Name}s.json");
            using (var streamReader = new StreamReader(stream))
            {
                var content = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(content);
            }
        }

        public int NumOfFoods => foods.Count;

        public Food this[int i] => foods[i];
    }
}