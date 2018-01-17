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

        private List<string> datas = new List<string>();

        private PlaceHolderFragment()
        {
        }

        public static PlaceHolderFragment GetInstance(string name)
        {
            var fragment = new PlaceHolderFragment();
            var args = new Bundle();
            args.PutString("data", name);
            fragment.Arguments = args;
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
            datas = ReadDatas(dataFileName);
            var arrayAdapter = new ArrayAdapter(container.Context, Android.Resource.Layout.SimpleListItem1, datas);
            listView.Adapter = arrayAdapter;
            listView.ItemClick += (s, e) =>
            {
                Toast.MakeText(container.Context, $"Click {datas[e.Position]}", ToastLength.Short).Show();
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