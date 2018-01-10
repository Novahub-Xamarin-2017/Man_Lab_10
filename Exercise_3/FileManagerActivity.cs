using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Exercise_3.Adapters;
using Java.IO;

namespace Exercise_3
{
    [Activity(Label = "FileManagerActivity", MainLauncher = true)]
    public class FileManagerActivity : ListActivity
    {
        private string path;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.acticity_show_files);

            path = (Intent.HasExtra("path")) ? Intent.GetStringExtra("path") : "/";
            var values = new List<string>();
            var dir = new File(path);
            if (dir.CanRead())
            {
                values.AddRange(dir.List().Select(item => path + (path.EndsWith(File.Separator) ? item : File.Separator + item)));
            }
            var adapter = new FileAdapter(values, this);
#pragma warning disable 618
            ListView.SetAdapter(adapter);
#pragma warning restore 618
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            var fileName = l.Adapter.GetItem(position).ToString();
            if (new File(fileName).IsDirectory)
            {
                var intent = new Intent(this, typeof(FileManagerActivity));
                intent.PutExtra("path", fileName);
                StartActivity(intent);
            }
            else
            {
                if (fileName.EndsWith(".jpg") || fileName.EndsWith(".png"))
                {
                    var intent = new Intent(this, typeof(DisplayImageActivity));
                    intent.PutExtra("fileImage", fileName);
                    StartActivity(intent);
                }
                else if (fileName.EndsWith(".mp3") || fileName.EndsWith(".mp4") || fileName.EndsWith(".flv"))
                {
                    var intent = new Intent(this, typeof(PlayVideoActivity));
                    intent.PutExtra("fileVideo", fileName);
                    StartActivity(intent);
                }
                else
                {
                    Toast.MakeText(this, fileName, ToastLength.Short).Show();
                }
            }
        }
    }
}