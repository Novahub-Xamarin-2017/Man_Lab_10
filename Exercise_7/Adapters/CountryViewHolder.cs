﻿using System;
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
using Exercise_7.Interfaces;
using Exercise_7.Models;

namespace Exercise_7.Adapters
{
    public class CountryViewHolder : RecyclerView.ViewHolder, View.IOnClickListener
    {
        [InjectView(Resource.Id.tvCountry)] private TextView tvCounTry;

        public IItemClickListener ItemClickListener { get; set; }

        public Country Country
        {
            set => tvCounTry.Text = value.CountryName;
        }

        public CountryViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
            itemView.SetOnClickListener(this);
        }

        public void OnClick(View v)
        {
            ItemClickListener.OnClick(v, AdapterPosition);
        }
    }
}