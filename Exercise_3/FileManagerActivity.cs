using System.Collections.Generic;
using System.IO;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Exercise_3.Adapters;
using File = Java.IO.File;

namespace Exercise_3
{
    [Activity(Label = "FileManagerActivity", MainLauncher = true)]
    public class FileManagerActivity : ListActivity
    {
        private readonly List<string> videoExtensions = new List<string> {".mp3", ".mp4", ".flv", ".3gp"};
        private readonly List<string> imageExtensions = new List<string> {".jpg", ".png"};

        private string path;

        private FileAdapter adapter;

        private readonly List<string> files = new List<string>();
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.acticity_show_files);
            UpdateListView(File.Separator);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            var fileName = l.Adapter.GetItem(position).ToString();
            if (new File(fileName).IsDirectory)
            {
                UpdateListView(fileName);
            }
            else
            {
                if (imageExtensions.Contains(Path.GetExtension(fileName))) 
                {
                    var intent = new Intent(this, typeof(DisplayImageActivity));
                    intent.PutExtra("fileImage", fileName);
                    StartActivity(intent);
                }
                else if (videoExtensions.Contains(Path.GetExtension(fileName)))
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

        private void UpdateListView(string filePath)
        {
            path = filePath;
            files.Clear();
            var dir = new File(filePath);
            if (dir.CanRead())
            {
                files.AddRange(dir.List().Select(file => Path.Combine(filePath, file)));
            }
            if (ListView.Adapter == null)
            {
                adapter = new FileAdapter(files);
                ListView.Adapter = adapter;
            }
            else
            {
                adapter.NotifyDataSetChanged();
            }
        }

        public override void OnBackPressed()
        {
            if (!path.Equals(File.Separator))
            {
                UpdateListView(Path.GetPathRoot(path));
                return;
            }
            Finish();
        }
    }
}