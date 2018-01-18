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

namespace Exercise_1.Adapter
{
    public class FoodViewHolder : RecyclerView.ViewHolder
    {
        public ImageView FoodImage { get; set; }
        public TextView TextViewFood { get; set; }
        public TextView TextViewCost { get; set; }

        public FoodViewHolder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public FoodViewHolder(View itemView) : base(itemView)
        {
            FoodImage = itemView.FindViewById<ImageView>(Resource.Id.imgFood);
            TextViewFood = itemView.FindViewById<TextView>(Resource.Id.txtFood);
            TextViewCost = itemView.FindViewById<TextView>(Resource.Id.txtCost);
        }
    }
}