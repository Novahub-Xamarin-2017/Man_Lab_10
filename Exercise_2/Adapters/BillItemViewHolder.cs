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

namespace Exercise_2.Adapters
{
    public class BillItemViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.img)] public ImageView Image;
        [InjectView(Resource.Id.txtPricePerUnit)] public TextView PricePerUnit;
        [InjectView(Resource.Id.txtName)] public TextView Name;
        [InjectView(Resource.Id.txtUnit)] public TextView Unit;
        [InjectView(Resource.Id.txtPrice)] public TextView Price;

        public BillItemViewHolder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public BillItemViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }

    }
}