using System;
using System.Collections.Generic;
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
    class ProductViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.img)] public ImageView Image;
        [InjectView(Resource.Id.txtPricePerUnit)] public TextView PricePerUnit;
        [InjectView(Resource.Id.txtName)] public TextView Name;
        [InjectView(Resource.Id.txtUnit)] public TextView Unit;
        [InjectView(Resource.Id.txtQuantity)] public TextView Quantity;

        [InjectOnClick(Resource.Id.btnAdd)]
        private void Increase(object sender, EventArgs e)
        {
            Quantity.Text = (Convert.ToInt32(Quantity.Text) + 1).ToString();
        }

        [InjectOnClick(Resource.Id.btnSub)]
        private void Descrease(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Quantity.Text) > 0)
            {
                Quantity.Text = (Convert.ToInt32(Quantity.Text) - 1).ToString();
            }
        }

        public ProductViewHolder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public ProductViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }
    }
}