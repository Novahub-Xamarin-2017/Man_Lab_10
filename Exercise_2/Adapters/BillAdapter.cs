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
using Android.Views;
using Android.Widget;
using Exercise_2.Models;

namespace Exercise_2.Adapters
{
    public class BillAdapter : RecyclerView.Adapter
    {
        private List<Order> Orders { get; }

        public BillAdapter(List<Order> orders)
        {
            Orders = orders;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is BillItemViewHolder viewHolder)
            {
                viewHolder.Name.Text = Orders[position].Product.Name;
                viewHolder.Unit.Text = $"{Orders[position].Quantity} x {Orders[position].Product.Unit}";
                viewHolder.PricePerUnit.Text =
                    $"Rs.{Orders[position].Product.PricePerUnit.ToString(CultureInfo.InvariantCulture)}";
                viewHolder.Price.Text = $"Price: {Orders[position].Product.PricePerUnit * Orders[position].Quantity}";
                viewHolder.Image.SetImageBitmap(OrderAdapter.GetImageBitmap(Orders[position].Product.ImageString));
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.item_bill_recyclerview, parent, false);
            return new BillItemViewHolder(itemView);
        }

        public override int ItemCount => Orders.Count;
    }
}