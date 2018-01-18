using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Exercise_5.Adapters;
using Exercise_5.Models;

namespace Exercise_5
{
    [Activity(Label = "Exercise_5", MainLauncher = true)]
    public class MainActivity : FragmentActivity
    {
        [InjectView(Resource.Id.recyclerView)] private RecyclerView recyclerView;

        private TaskViewAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);

            recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            
            adapter = new TaskViewAdapter(new List<Task>(), this);
            
            recyclerView.SetAdapter(adapter);
        }
    }
}

