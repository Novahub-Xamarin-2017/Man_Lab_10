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

namespace Exercise_5.Models
{
    public class Task
    {
        public string Subject { get; set; }
        public string Exercise { get; set; }
        public string Lesson { get; set; }
        public DateTime TimeEnd { get; set; }
        public int TimeLimited { get; set; }
    }
}