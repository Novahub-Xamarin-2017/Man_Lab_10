using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Exercise_2.Models;

namespace Exercise_2.Adapters
{
    public class OrderAdapter : RecyclerView.Adapter
    {
        public ListOrders Orders { get; set; }

        public OrderAdapter(ListOrders orders)
        {
            Orders = orders;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (!(holder is ProductViewHolder viewHolder)) return;
            viewHolder.Name.Text = Orders[position].Product.Name;
            viewHolder.Unit.Text = Orders[position].Product.Unit;
            viewHolder.PricePerUnit.Text =
                $"Rs.{Orders[position].Product.PricePerUnit.ToString(CultureInfo.InvariantCulture)}";
            viewHolder.Quantity.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                Orders[position].Quantity = Convert.ToInt32(viewHolder.Quantity.Text);
                Log.Info("log", "value " + Orders[position].Quantity);
                Log.Info("log", "sum " + Orders.SumOfPrices);
            };
            
            viewHolder.Image.SetImageBitmap(GetImageBitmap(Orders[position].Product.ImageString));
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.recyclerview_item, parent, false);
            return new ProductViewHolder(itemView);
        }

        private Bitmap GetImageBitmap(string encodedString)
        {
            var pureBase64Encoded = encodedString.Substring(encodedString.IndexOf(",", StringComparison.Ordinal) + 1);
            var decodedString = Base64.Decode(pureBase64Encoded, Base64.Default);
            return BitmapFactory.DecodeByteArray(decodedString, 0, decodedString.Length);
        }

        public override int ItemCount => Orders.NumberOfOrders;
    }
}