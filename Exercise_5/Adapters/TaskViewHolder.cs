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

namespace Exercise_5.Adapters
{
    public class TaskViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.tvSubject)] public TextView tvSubject;

        [InjectView(Resource.Id.tvExercise)] public TextView tvExercise;

        [InjectView(Resource.Id.tvLesson)] public TextView tvLesson;

        [InjectView(Resource.Id.tvTimeEnd)] public TextView tvTimeEnd;

        [InjectView(Resource.Id.tvTimeLimited)] public TextView tvTimeLimmited;

        [InjectView(Resource.Id.btnDaysLeft)] public Button btnDaysLeft;

        [InjectView(Resource.Id.btnResume)] public Button btnResume;

        [InjectView(Resource.Id.view)] public View view;

        public TaskViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }
    }
}