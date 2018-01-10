using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Exercise_5.Models;

namespace Exercise_5.Adapters
{
    public class TaskViewAdapter :RecyclerView.Adapter
    {
        public List<Task> Tasks { get; set; }

        public TaskViewAdapter()
        {
            Tasks = new List<Task>
            {
                new Task
                {
                    Subject = "CS-101 Python",
                    Exercise = "Exercise 6",
                    Lesson = "Data Structures",
                    TimeEnd = new DateTime(2018, 1, 12),
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
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (!(holder is TaskViewHolder viewHolder)) return;
            var task = Tasks[position];
            viewHolder.tvSubject.Text = task.Subject + ",";
            viewHolder.tvExercise.Text = task.Exercise + ",";
            viewHolder.tvLesson.Text = task.Lesson;
            viewHolder.tvTimeEnd.Text = task.TimeEnd.ToString("d");
            viewHolder.tvTimeLimmited.Text = task.TimeLimited + " Minutes";

            var daysLeft = (task.TimeEnd - DateTime.Now).Days;
            if (daysLeft > 0)
            {
                viewHolder.btnDaysLeft.Text = daysLeft + (daysLeft == 1 ? " day left" : " days left");
                viewHolder.btnDaysLeft.SetCompoundDrawablesWithIntrinsicBounds(Resource.Drawable.warning, 0, 0, 0);
                viewHolder.btnResume.Text = "Resume";
                viewHolder.btnResume.SetCompoundDrawablesWithIntrinsicBounds(Resource.Drawable.resume, 0, 0, 0);
                viewHolder.view.SetBackgroundColor(Color.Red);
            }
            else
            {
                viewHolder.btnDaysLeft.Text = "Assignment Completed";
                viewHolder.btnDaysLeft.SetCompoundDrawablesWithIntrinsicBounds(Resource.Drawable.ok, 0, 0, 0);
                viewHolder.btnResume.Text = "Report";
                viewHolder.btnResume.SetCompoundDrawablesWithIntrinsicBounds(Resource.Drawable.report, 0, 0, 0);
                viewHolder.view.SetBackgroundColor(Color.Green);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.task_item, parent, false);
            return new TaskViewHolder(itemView);
        }

        public override int ItemCount => Tasks.Count;
    }
}