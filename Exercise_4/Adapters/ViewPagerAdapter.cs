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
using Java.Lang;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace Exercise_4.Adapters
{
    public class ViewPagerAdapter : FragmentPagerAdapter
    {
        private List<Fragment> fragments = new List<Fragment>();

        private List<string> fragmentTitles = new List<string>();

        public ViewPagerAdapter(FragmentManager fm) : base(fm)
        {
        }

        public override int Count => fragments.Count;

        public override Fragment GetItem(int position)
        {
            return fragments[position];
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(fragmentTitles[position].ToLower());
        }

        public void AddFragment(Fragment fragment, string title)
        {
            fragments.Add(fragment);
            fragmentTitles.Add(title);
        }
    }
}