using System;
using Android.OS;
using Java.Interop;
using Object = Java.Lang.Object;

namespace Exercise_5.Models
{
    public class Task : Object, IParcelable
    {
        public string Subject { get; set; }
        public string Exercise { get; set; }
        public string Lesson { get; set; }
        public DateTime TimeEnd { get; set; }
        public int TimeLimited { get; set; }

        [ExportField("Creator")]
        public static TaskParcelableCreator InititalizeCreator()
        {
            return new TaskParcelableCreator();
        }

        public int DescribeContents()
        {
            return 0;
        }

        public void WriteToParcel(Parcel dest, ParcelableWriteFlags flags)
        {
            dest.WriteString(Subject);
            dest.WriteString(Exercise);
            dest.WriteString(Lesson);
            dest.WriteString(TimeEnd.ToString("d"));
            dest.WriteInt(TimeLimited);
        }
    }
    public class TaskParcelableCreator : Object, IParcelableCreator
    {
        public Object CreateFromParcel(Parcel source)
        {
            var task = new Task
            {
                Subject = source.ReadString(),
                Exercise = source.ReadString(),
                Lesson = source.ReadString(),
                TimeEnd = DateTime.Parse(source.ReadString()),
                TimeLimited = source.ReadInt()
            };
            return task;
        }

        public Object[] NewArray(int size)
        {
            return new Object[size];
        }
    }
}