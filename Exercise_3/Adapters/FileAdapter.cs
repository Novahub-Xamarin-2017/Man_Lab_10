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
using Object = Java.Lang.Object;

namespace Exercise_3.Adapters
{
    public class FileAdapter : BaseAdapter
    {
        private readonly List<string> files;

        public FileAdapter(List<string> files)
        {
            this.files = files;
        }
        public override Object GetItem(int position)
        {
            return files[position];
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? LayoutInflater.From(parent.Context).Inflate(
                           Resource.Layout.list_file_item, parent, false);
            var txtName = view.FindViewById<TextView>(Resource.Id.txtName);
            var img = view.FindViewById<ImageView>(Resource.Id.imageView);
            var fileName = files[position];
            txtName.Text = fileName.Split('/').Last();
            img.SetImageResource(new File(fileName).IsDirectory ? Resource.Drawable.folder : Resource.Drawable.file);
            return view;
        }

        public override int Count => files.Count;
    }
}