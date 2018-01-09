using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Exercise_2.Adapters;
using Exercise_2.Models;
using Newtonsoft.Json;

namespace Exercise_2
{
    [Activity(Label = "BILL", Theme = "@style/MyTheme")]
    public class ShowBillActicity : Activity
    {
        [InjectView(Resource.Id.txtSumPrices)] private TextView tvSumPrices;
        [InjectView(Resource.Id.recyclerViewBill)] private RecyclerView recyclerViewBill;
        [InjectView(Resource.Id.toolbar)] private Android.Widget.Toolbar toolbar;
        private BillAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.acticity_show_bill);
            
            Cheeseknife.Inject(this);
            SetActionBar(toolbar);
            tvSumPrices.Text = $"Sum of price: {ListOrders.GetInstance.SumOfPrices}";
            recyclerViewBill.SetLayoutManager(new LinearLayoutManager(this));
            adapter = new BillAdapter(ListOrders.GetInstance.Orders.Where(x => x.Quantity != 0).ToList());
            recyclerViewBill.SetAdapter(adapter);
            //Create your application here
        }
    }
}