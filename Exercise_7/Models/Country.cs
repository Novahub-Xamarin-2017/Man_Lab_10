using System;
using System.Collections.Generic;
using System.Linq;
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

        public static List<Country> MatchFilter(List<Country> datas, string searchString)
        {
            return datas.Where(x => x.CountryName.ToLower().Contains(searchString.ToLower())).ToList();
        }
    }
}