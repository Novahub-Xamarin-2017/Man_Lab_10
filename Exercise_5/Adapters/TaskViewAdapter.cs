using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Exercise_5.Interfaces;
using Exercise_5.Models;

namespace Exercise_5.Adapters
{
    public class TaskViewAdapter : RecyclerView.Adapter, IItemClickListener
    {
        public List<Task> Tasks;
        private readonly Context context;

        public TaskViewAdapter(List<Task> tasks,Context context)
        {
            Tasks = new List<Task>
            {
                new Task
                {
                    Subject = "CS-101 Python",
                    Exercise = "Exercise 6",
                    Lesson = "Data Structures",
                    TimeEnd = new DateTime(2018, 1, 16),
                    TimeLimited = 45
                },
                new Task
                {
                    Subject = "CS-101 Python",
                    Exercise = "Exercise 5",
                    Lesson = "Modules & Functions",
                    TimeEnd = new DateTime(2018, 1, 10),
                    TimeLimited = 60
                },
                new Task
                {
                    Subject = "CS-101 Python",
                    Exercise = "Exercise 4",
                    Lesson = "Control Flow (if, while and for loop)",
                    TimeEnd = new DateTime(2017, 12, 9),
                    TimeLimited = 40
                }
            };
            this.context = context;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (!(holder is TaskViewHolder viewHolder)) return;
            var task = Tasks[position];
            viewHolder.TvSubject.Text = task.Subject + ",";
            viewHolder.TvExercise.Text = task.Exercise + ",";
            viewHolder.TvLesson.Text = task.Lesson;
            viewHolder.TvTimeEnd.Text = task.TimeEnd.ToString("d");
            viewHolder.TvTimeLimmited.Text = task.TimeLimited + " Minutes";

            var daysLeft = (task.TimeEnd - DateTime.Now).Days;
            if (daysLeft > 0)
            {
                viewHolder.BtnDaysLeft.Text = daysLeft + (daysLeft == 1 ? " day left" : " days left");
                viewHolder.BtnDaysLeft.SetCompoundDrawablesWithIntrinsicBounds(Resource.Drawable.warning, 0, 0, 0);
                viewHolder.BtnResume.Text = "Resume";
                viewHolder.BtnResume.SetCompoundDrawablesWithIntrinsicBounds(Resource.Drawable.resume, 0, 0, 0);
                viewHolder.View.SetBackgroundColor(Color.Red);
            }
            else
            {
                viewHolder.BtnDaysLeft.Text = "Assignment Completed";
                viewHolder.BtnDaysLeft.SetCompoundDrawablesWithIntrinsicBounds(Resource.Drawable.ok, 0, 0, 0);
                viewHolder.BtnResume.Text = "Report";
                viewHolder.BtnResume.SetCompoundDrawablesWithIntrinsicBounds(Resource.Drawable.report, 0, 0, 0);
                viewHolder.View.SetBackgroundColor(Color.Green);
            }
            viewHolder.ItemClickListener = this;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.task_item, parent, false);
            return new TaskViewHolder(itemView);
        }

        public override int ItemCount => Tasks.Count;

        public void OnClick(View itemView, int position, bool isLongClick)
        {
            if (isLongClick) return;
            var taskInfomationDialog = new TaskInfomationDialog();
            var bundle = new Bundle();
            bundle.PutParcelable("task", Tasks[position]);
            taskInfomationDialog.Arguments = bundle;
            taskInfomationDialog.Show(((FragmentActivity) context).FragmentManager.BeginTransaction(), "tag");
        }
    }
}