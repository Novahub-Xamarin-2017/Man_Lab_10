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