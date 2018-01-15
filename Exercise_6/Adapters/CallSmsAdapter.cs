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
    public class CallSmsAdapter : RecyclerView.Adapter
    {
        private List<object> callSmsObjects;

        private const int CallType = 1;

        private const int SmsType = 2;

        public CallSmsAdapter(List<object> callSmsObjects)
        {
            this.callSmsObjects = callSmsObjects;
        }

        public override int GetItemViewType(int position)
        {
            switch (callSmsObjects[position])
            {
                case Call _:
                    return CallType;
                case Sms _:
                    return SmsType;
            }
            return -1;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var viewType = holder.ItemViewType;
            switch (viewType)
            {
                case CallType:
                    ((CallViewHolder)holder).Call = (Call)callSmsObjects[position];
                    break;
                case SmsType:
                    ((SmsViewHolder)holder).Sms = (Sms)callSmsObjects[position];
                    break;
                default:
                    return;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            RecyclerView.ViewHolder viewHolder;
            switch (viewType)
            {
                case CallType:
                    var callView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.call_item, parent, false);
                    viewHolder = new CallViewHolder(callView);
                    break;
                case SmsType:
                    var smsView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.sms_item, parent, false);
                    viewHolder = new SmsViewHolder(smsView);
                    break;
                default:
                    viewHolder = null;
                    break;
            }
            return viewHolder;
        }

        public override int ItemCount => callSmsObjects.Count;
    }
}