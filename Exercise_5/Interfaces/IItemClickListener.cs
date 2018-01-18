using Android.Views;

namespace Exercise_5.Interfaces
{
    public interface IItemClickListener
    {
        void OnClick(View itemView, int position, bool isLongClick);
    }
}