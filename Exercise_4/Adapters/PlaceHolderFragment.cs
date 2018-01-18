using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Fragment = Android.App.Fragment;

namespace Exercise_4.Adapters
{
    public class PlaceHolderFragment : Fragment
    {
        [InjectView(Resource.Id.linearLayoutFragment)] private LinearLayout linearLayout;

        [InjectView(Resource.Id.listView)] private ListView listView;

        private List<string> items = new List<string>();

        private PlaceHolderFragment()
        {
        }

        public static PlaceHolderFragment GetInstance(string name)
        {
            var fragment = new PlaceHolderFragment();
            var bundle = new Bundle();
            bundle.PutString("data", name);
            fragment.Arguments = bundle;
            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_layout, container, false);
            Cheeseknife.Inject(this, view);
            Init(container);
            return view;
        }

        private void Init(ViewGroup container)
        {
            var dataFileName = Arguments.GetString("data");
            items = ReadDatas(dataFileName);
            var arrayAdapter = new ArrayAdapter(container.Context, Android.Resource.Layout.SimpleListItem1, items);
            listView.Adapter = arrayAdapter;
            listView.ItemClick += (s, e) =>
            {
                Toast.MakeText(container.Context, $"Click {items[e.Position]}", ToastLength.Short).Show();
            };
        }

        private List<string> ReadDatas(string dataFileName)
        {
            var stream = Application.Context.Assets.Open($"{dataFileName}.json");
            using (var streamReader = new StreamReader(stream))
            {
                var content = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<string>>(content);
            }
        }
    }
}