using System;
using System.Collections.Generic;
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
using Exercise_1.Models;

namespace Exercise_1.Adapter
{
    public class FoodViewAdapter : RecyclerView.Adapter
    {
        public ListFood Foods { get; }

        public FoodViewAdapter(ListFood foods)
        {
            Foods = foods;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (!(holder is FoodViewHolder foodViewHolder)) return;
            foodViewHolder.TextViewCost.Text = Foods[position].FoodCost;
            foodViewHolder.TextViewFood.Text = Foods[position].FoodName;
            foodViewHolder.FoodImage.SetImageBitmap(GetBitmapFromBase64String(Foods[position].ImageString));
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).
                Inflate(Resource.Layout.food_view_item, parent, false);
            return new FoodViewHolder(itemView);
        }

        public override int ItemCount => Foods.NumOfFoods;

        private Bitmap GetBitmapFromBase64String(string encodedString)
        {
            var pureBase64Encoded = encodedString.Substring(encodedString.IndexOf(",", StringComparison.Ordinal) + 1);
            var decodedString = Base64.Decode(pureBase64Encoded, Base64Flags.Default);
            return BitmapFactory.DecodeByteArray(decodedString, 0, decodedString.Length);
        }
    }
}