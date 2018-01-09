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
                values.AddRange(dir.List());
            }
            var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, values);
            ListView.SetAdapter(adapter);

            // Create your application here
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            var fileName = l.Adapter.GetItem(position).ToString();
            if (path.EndsWith(File.Separator))
            {
                fileName = path + fileName;
            }
            else
            {
                fileName = path + File.Separator + fileName;
            }
            if (new File(fileName).IsDirectory)
            {
                var intent = new Intent(this, typeof(FileManagerActivity));
                intent.PutExtra("path", fileName);
                StartActivity(intent);
            }
            else
            {
                Toast.MakeText(this, fileName + "is not a directory", ToastLength.Short).Show();
            }
        }
    }
}