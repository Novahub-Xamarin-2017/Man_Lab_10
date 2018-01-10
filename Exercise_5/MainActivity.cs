using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Exercise_5.Adapters;

namespace Exercise_5
{
    [Activity(Label = "Exercise_5", MainLauncher = true)]
    public class MainActivity : Activity
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
            adapter = new TaskViewAdapter();
            recyclerView.SetAdapter(adapter);
        }
    }
}

