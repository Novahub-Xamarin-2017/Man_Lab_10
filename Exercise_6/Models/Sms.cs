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

namespace Exercise_6.Models
{
    public class Sms
    {
        public string Sender { get; set; }
        public string PhoneNumber { get; set; }
        public string Content { get; set; }
        public DateTime TimeReceived { get; set; }
    }
}