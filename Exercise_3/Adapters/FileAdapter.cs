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
using Exercise_3.Interfaces;

namespace Exercise_3.Adapters
{
    public class FileAdapter : RecyclerView.Adapter, IItemClickListener
    {

        public List<string> Files { get; }
        private Context context;

        public FileAdapter(List<string> files, Context context)
        {
            Files = files;
            this.context = context;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is ItemViewHolder viewholder)
            {
                viewholder.TvName.Text = Files[position];
                viewholder.SetOnItemClickListener(this);
            }
        }


        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.recyclerview_item, parent, false);
            return new ItemViewHolder(itemView);
        }

        public override int ItemCount => Files.Count;
        public void OnClick(View itemView, int position, bool isLongClick)
        {
            if (isLongClick)
            {
                Toast.MakeText(context, $"Long click : {Files[position]}", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(context, $"{Files[position]}", ToastLength.Short).Show();
            }
        }
    }
}