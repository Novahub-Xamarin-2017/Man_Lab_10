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
            var foodViewHolder = holder as FoodViewHolder;
            foodViewHolder.TextViewCost.Text = Foods[position].FoodCost;
            foodViewHolder.TextViewFood.Text = Foods[position].FoodName;
            var encodedString = Foods[position].ImageString;

            var pureBase64Encoded = encodedString.Substring(encodedString.IndexOf(",", StringComparison.Ordinal) + 1);
            var decodedString = Base64.Decode(pureBase64Encoded, Base64.Default);
            var bitmap = BitmapFactory.DecodeByteArray(decodedString, 0, decodedString.Length);
            foodViewHolder.FoodImage.SetImageBitmap(bitmap);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).
                Inflate(Resource.Layout.food_view_item, parent, false);
            return new FoodViewHolder(itemView);
        }

        public override int ItemCount => Foods.NumOfFoods;
    }
}