using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Exercise_7.Adapters;
using Exercise_7.Models;
using Java.Interop;
using Newtonsoft.Json;
using SearchView = Android.Widget.SearchView;

namespace Exercise_7
{
    [Activity(Label = "Exercise_7", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light")]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.recyclerView)] private RecyclerView recyclerView;

        [InjectView(Resource.Id.searchView)] private SearchView searchView;

        private List<Country> countries;

        private CountryAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
            Init();
        }

        private void Init()
        {
            countries = new List<Country>();
            var stream = Application.Context.Assets.Open("Countries.json");
            using (var streamReader = new StreamReader(stream))
            {
                var content = streamReader.ReadToEnd();
                countries =  JsonConvert.DeserializeObject<List<Country>>(content);
            }
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            adapter = new CountryAdapter(countries, this);
            recyclerView.SetAdapter(adapter);

            searchView.QueryTextChange += (s, e) => adapter.Filter.InvokeFilter(e.NewText);
            searchView.QueryTextSubmit += (s, e) =>
            {
                Toast.MakeText(this, "Search for: " + e.Query, ToastLength.Short).Show();
                e.Handled = true;
            };
        }
    }
}

