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
    public class SmsViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.tvSender)] private TextView tvSender;

        [InjectView(Resource.Id.tvMessage)] private TextView tvMessage;

        [InjectView(Resource.Id.tvTimeReceived)] private TextView tvTimeReceived;

        public Sms Sms
        {
            set
            {
                tvSender.Text = value.Sender;
                tvMessage.Text = value.Content;
                tvTimeReceived.Text = value.TimeReceived.ToShortTimeString();
            }
        }
        public SmsViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }
    }
}