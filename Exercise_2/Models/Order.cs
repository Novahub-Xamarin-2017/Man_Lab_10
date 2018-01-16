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

namespace Exercise_2.Models
{
    public class Order
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}