using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace Exercise_4.Adapters
{
    public class ViewPagerAdapter : FragmentPagerAdapter
    {
        private List<Fragment> fragments = new List<Fragment>();

        private List<string> titles = new List<string>();

        public ViewPagerAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public ViewPagerAdapter(FragmentManager fm) : base(fm)
        {
        }

        public override int Count => fragments.Count;
        public override Fragment GetItem(int position)
        {
            throw new NotImplementedException();
        }
    }
}