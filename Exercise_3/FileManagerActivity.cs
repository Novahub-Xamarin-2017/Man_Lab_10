using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
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

        private string path = File.Separator;

        private string root;

        private static FileAdapter adapter;

        private static readonly List<string> files = new List<string>();
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.acticity_show_files);
            UpdateListView(ListView, path);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            var fileName = l.Adapter.GetItem(position).ToString();
            if (new File(fileName).IsDirectory)
            {
                UpdateListView(l, fileName);
                root = path;
                path = fileName;
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

        private static void UpdateListView(ListView listview,string filePath)
        {
            files.Clear();
            var dir = new File(filePath);
            if (dir.CanRead())
            {
                files.AddRange(dir.List().Select(file => Path.Combine(filePath, file)));
            }
            if (listview.Adapter == null)
            {
                adapter = new FileAdapter(files);
                listview.Adapter = adapter;
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
                UpdateListView(ListView, root);
                path = root;
                root = Path.GetPathRoot(root);
                return;
            }
            Finish();
        }
    }
}