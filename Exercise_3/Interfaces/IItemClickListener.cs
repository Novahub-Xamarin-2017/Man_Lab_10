using Android.Views;

namespace Exercise_3.Interfaces
{
    public interface IItemClickListener
    {
        void OnClick(View itemView, int position, bool isLongClick);
    }
}