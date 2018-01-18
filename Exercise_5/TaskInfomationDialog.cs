using System;
using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Exercise_5.Models;

namespace Exercise_5
{
    public class TaskInfomationDialog : DialogFragment
    {
        [InjectView(Resource.Id.tvSubject)] private TextView tvSubject;

        [InjectView(Resource.Id.tvExercise)] private TextView tvExercise;

        [InjectView(Resource.Id.tvLesson)] private TextView tvLesson;

        [InjectView(Resource.Id.tvDateEnd)] private TextView tvDateEnd;

        [InjectView(Resource.Id.tvTimeLimited)] private TextView tvTimeLimited;

        [InjectView(Resource.Id.tvStatus)] private TextView tvStatus;

        [InjectOnClick(Resource.Id.btnClose)]
        private void Close(object sender, EventArgs e)
        {
            Dismiss();
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            var view =  inflater.Inflate(Resource.Layout.task_infomation, container, false);
            Cheeseknife.Inject(this, view);

            var task = (Task) Arguments.GetParcelable("task");
            Log.Info("Date End", task.TimeEnd.ToString("d"));
            tvSubject.Text = task.Subject;
            tvExercise.Text = task.Exercise;
            tvLesson.Text = task.Lesson;
            tvDateEnd.Text = task.TimeEnd.ToString("d");
            tvTimeLimited.Text = task.TimeLimited.ToString();
            tvStatus.Text = (task.TimeEnd <= DateTime.Now) ? "Completed" : "In progress";
            return view;
        }
    }
}