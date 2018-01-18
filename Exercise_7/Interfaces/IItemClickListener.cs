using Android.Views;

namespace Exercise_7.Interfaces
{
    public interface IItemClickListener
    {
        void OnClick(View itemView, int position);
    }
}