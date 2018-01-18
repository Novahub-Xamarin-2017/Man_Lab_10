using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Exercise_5.Interfaces;

namespace Exercise_5.Adapters
{
    public class TaskViewHolder : RecyclerView.ViewHolder, View.IOnClickListener, View.IOnLongClickListener
    {
        [InjectView(Resource.Id.tvSubject)] public TextView TvSubject;

        [InjectView(Resource.Id.tvExercise)] public TextView TvExercise;

        [InjectView(Resource.Id.tvLesson)] public TextView TvLesson;

        [InjectView(Resource.Id.tvTimeEnd)] public TextView TvTimeEnd;

        [InjectView(Resource.Id.tvTimeLimited)] public TextView TvTimeLimmited;

        [InjectView(Resource.Id.btnDaysLeft)] public Button BtnDaysLeft;

        [InjectView(Resource.Id.btnResume)] public Button BtnResume;

        [InjectView(Resource.Id.view)] public View View;

        public IItemClickListener ItemClickListener { get; set; }

        public TaskViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
            itemView.SetOnClickListener(this);
            itemView.SetOnLongClickListener(this);
        }

        public void OnClick(View v)
        {
            ItemClickListener.OnClick(v, AdapterPosition, false);
        }

        public bool OnLongClick(View v)
        {
            ItemClickListener.OnClick(v, AdapterPosition, true);
            return true;
        }
    }
}