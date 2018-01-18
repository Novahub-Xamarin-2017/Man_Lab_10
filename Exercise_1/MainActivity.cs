using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Exercise_1.Adapter;
using Exercise_1.Models;

namespace Exercise_1
{
    [Activity(Label = "Exercise_1", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private RecyclerView recyclerView;
        private RecyclerView.LayoutManager layoutManager;
        private FoodViewAdapter foodViewAdapter;
        private ListFood foods;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            foods = new ListFood();
            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);
            foodViewAdapter = new FoodViewAdapter(foods);
            recyclerView.SetAdapter(foodViewAdapter);
        }
    }
}

