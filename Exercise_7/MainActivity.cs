using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Exercise_7.Adapters;
using Exercise_7.Models;

namespace Exercise_7
{
    [Activity(Label = "Exercise_7", MainLauncher = true)]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.recyclerView)] private RecyclerView recyclerView;

        private List<Country> countries;

        private CountryAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);

            recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            Init();
        }

        private void Init()
        {
            countries = new List<Country>
            {
                new Country
                {
                    CountryName = "Australia",
                    CountryInfo = ""
                },
                new Country
                {
                    CountryName = "Brazil",
                    CountryInfo = ""
                }
            };
            adapter = new CountryAdapter(countries);
            recyclerView.SetAdapter(adapter);
        }
    }
}

