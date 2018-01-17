using System;
using Android.Runtime;

namespace Exercise_7.Models
{
    public class Country : IJavaObject
    {
        public string CountryName { get; set; }
        public string CountryInfo { get; set; }
        public void Dispose()
        {
            
        }

        public IntPtr Handle { get; }
    }
}