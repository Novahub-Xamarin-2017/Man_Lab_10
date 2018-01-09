using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Exercise_2.Models;

namespace Exercise_2.Adapters
{
    public class BillItemViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.img)] public ImageView Image;
        [InjectView(Resource.Id.txtPricePerUnit)] public TextView PricePerUnit;
        [InjectView(Resource.Id.txtName)] public TextView Name;
        [InjectView(Resource.Id.txtUnit)] public TextView Unit;
        [InjectView(Resource.Id.txtPrice)] public TextView Price;

        public Order BillItem { get; set; }

        public BillItemViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }
    }
}