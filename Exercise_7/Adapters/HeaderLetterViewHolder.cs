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

namespace Exercise_7.Adapters
{
    public class HeaderLetterViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.tvHeaderLetter)] private TextView tvHeaderLetter;

        public string Letter
        {
            set => tvHeaderLetter.Text = value;
        }

        public HeaderLetterViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }
    }
}