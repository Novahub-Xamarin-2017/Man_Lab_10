using System.Collections.Generic;
using System.IO;
using System.Linq;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Exercise_3.Adapters;

namespace Exercise_3
{
    [Activity(Label = "Exercise_3", MainLauncher = true)]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.recyclerView)] private RecyclerView recyclerView;
        private FileAdapter adapter;
        private RecyclerView.LayoutManager layoutManager;
        private List<string> files;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
            layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);
            var path = "/";
            files = Directory.GetDirectories(path).ToList();
            foreach (var item in Directory.GetFiles(path))
            {
                files.Add(item);
            }
            foreach (var item in Directory.GetFileSystemEntries(path))
            {
                files.Add(item);
            }
            adapter = new FileAdapter(files, this);
            recyclerView.SetAdapter(adapter);
        }
    }
}

