using System;
using System.Collections.Generic;
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
using Java.IO;

namespace Exercise_3
{
    [Activity(Label = "FileManagerActivity", MainLauncher = true)]
    public class FileManagerActivity : ListActivity
    {
        private static readonly List<string> VideoExtensions = new List<string> {".mp3", ".mp4", ".flv", ".3gp"};
        private static readonly List<string> ImageExtensions = new List<string> {".jpg", ".png"};

        private string path = File.Separator;

        private string root;
        
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
                if (ImageExtensions.Contains(fileName.Substring(fileName.LastIndexOf(".", StringComparison.Ordinal)))) 
                {
                    var intent = new Intent(this, typeof(DisplayImageActivity));
                    intent.PutExtra("fileImage", fileName);
                    StartActivity(intent);
                }
                else if (VideoExtensions.Contains(fileName.Substring(fileName.LastIndexOf(".", StringComparison.Ordinal))))
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

        private void UpdateListView(AbsListView listview,string filePath)
        {
            var values = new List<string>();
            var dir = new File(filePath);
            if (dir.CanRead())
            {
                values.AddRange(dir.List().Select(item => filePath + (filePath.EndsWith(File.Separator) ? item : File.Separator + item)));
            }
            var adapter = new FileAdapter(values, this);
#pragma warning disable 618
            listview.SetAdapter(adapter);
#pragma warning restore 618
            listview.DeferNotifyDataSetChanged();
        }

        public override void OnBackPressed()
        {

            if (!path.Equals(File.Separator))
            {
                UpdateListView(ListView, root);
                path = root;
                root = root.Remove(root.LastIndexOf(File.Separator, StringComparison.Ordinal));
            }
            else
            {
                Finish();
            }
        }
    }
}