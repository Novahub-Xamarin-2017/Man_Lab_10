using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;

namespace Exercise_4
{
    [Activity(Label = "Exercise_4", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
        }
    }
}

