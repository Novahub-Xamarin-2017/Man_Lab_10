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
using Exercise_6.Models;

namespace Exercise_6.Adapters
{
    public class CallViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.tvCaller)] private TextView tvCaller;

        [InjectView(Resource.Id.tvTimeReceived)] private TextView tvTimeReceived;

        public Call Call
        {
            set
            {
                tvCaller.Text = value.Caller;
                tvTimeReceived.Text = value.TimeReceived.ToShortTimeString();
            }
        }
        public CallViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }
    }
}