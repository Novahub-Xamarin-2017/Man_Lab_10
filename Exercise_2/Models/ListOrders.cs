using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace Exercise_2.Models
{
    public class ListOrders
    {
        private static ListOrders instance;

        public static ListOrders GetInstance => instance ?? (instance = new ListOrders());

        public List<Order> Orders { get; set; }

        private ListOrders()
        {
            Orders = ReadJson<Order>();
        }

        public List<T> ReadJson<T>()
        {
            var stream = Application.Context.Assets.Open($"{typeof(T).Name}s.json");
            var streamReader = new StreamReader(stream);
            var content = streamReader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<T>>(content);
        }

        public double SumOfPrices => Orders.Sum(x => x.Quantity * x.Product.PricePerUnit);

        public Order this[int i] => Orders[i];

        public int NumberOfOrders => Orders.Count;
    }
}