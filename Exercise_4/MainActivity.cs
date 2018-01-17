using Android.App;
using Android.OS;
using Exercise_4.Adapters;

namespace Exercise_4
{
    [Activity(Label = "Exercise_4", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            AddNewTab("Applications");
            AddNewTab("Books");
            AddNewTab("Games");
        }

        private void AddNewTab(string tabTitle)
        {
            var tab = ActionBar.NewTab();
            tab.SetText(tabTitle);
            tab.TabSelected += (s, e) =>
            {
                var fragmentTransaction = FragmentManager.BeginTransaction();
                fragmentTransaction.Replace(Resource.Id.linearLayout, PlaceHolderFragment.GetInstance(tabTitle));
                fragmentTransaction.Commit();
            };
            ActionBar.AddTab(tab);
        }
    }
}

