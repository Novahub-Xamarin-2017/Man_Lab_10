using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
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
            switch (holder)
            {
                case CallViewHolder callViewHolder:
                    callViewHolder.Call = (Call)callSmsObjects[position];
                    break;
                case SmsViewHolder smsViewHolder:
                    smsViewHolder.Sms = (Sms)callSmsObjects[position];
                    break;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var layoutInflater = LayoutInflater.From(parent.Context);
            switch (viewType)
            {
                case CallType:
                    var callView = layoutInflater.Inflate(Resource.Layout.call_item, parent, false);
                    return new CallViewHolder(callView);
                case SmsType:
                    var smsView = layoutInflater.Inflate(Resource.Layout.sms_item, parent, false);
                    return new SmsViewHolder(smsView);
                default:
                    return null;
            }
        }

        public override int ItemCount => callSmsObjects.Count;
    }
}