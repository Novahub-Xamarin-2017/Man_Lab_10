using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Util;
using Exercise_2.Adapters;
using Exercise_2.Models;
using Java.Interop;
using Newtonsoft.Json;

namespace Exercise_2
{
    [Activity(Label = "Exercise_2", MainLauncher = true, Theme = "@style/MyTheme")]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.recyclerView)] private RecyclerView recyclerView;
        [InjectView(Resource.Id.toolbar)] private Android.Widget.Toolbar toolbar;

        [InjectOnClick(Resource.Id.btnShowBill)]
        private void StartActivityShowBill(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ShowBillActicity));
            StartActivity(intent);
        }
        private RecyclerView.LayoutManager layoutManager;
        private ListOrders orders;
        private OrderAdapter orderAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
            SetActionBar(toolbar);
            layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);
            orders = ListOrders.GetInstance;
            orderAdapter = new OrderAdapter(orders);
            recyclerView.SetAdapter(orderAdapter);
        }
    }
}

