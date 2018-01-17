using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Exercise_7.Extensions;
using Exercise_7.Interfaces;
using Exercise_7.Models;
using Java.Lang;

namespace Exercise_7.Adapters
{
    public class CountryAdapter : RecyclerView.Adapter, IItemClickListener, IFilterable
    {
        private const int TypeName = 1;

        private const int TypeLetter = 2;

        private List<object> sectionLetterCountries;

        private readonly Context context;

        private readonly List<Country> countriesList;

        private List<Country> originalDatas;

        private static List<object> GetSectionLetterCountriesList(IEnumerable<Country> countries)
        {
            var headerLetterCountries = new List<object>();
            headerLetterCountries.AddRange(countries.OrderBy(x => x.CountryName));
            var sectionLetter = "";
            for (var iCount = 0; iCount < headerLetterCountries.Count; iCount++)
            {
                var firstLetter = ((Country)headerLetterCountries[iCount]).CountryName[0].ToString();
                if (sectionLetter.Equals(firstLetter)) continue;
                sectionLetter = firstLetter;
                headerLetterCountries.Insert(iCount, firstLetter);
                iCount++;
            }
            return headerLetterCountries;
        }

        public CountryAdapter(IEnumerable<Country> countries, Context context)
        {
            var enumerable = countries as IList<Country> ?? countries.ToList();
            countriesList = enumerable.OrderBy(x => x.CountryName).ToList();
            sectionLetterCountries = GetSectionLetterCountriesList(enumerable);
            this.context = context;
            Filter = new CountryFilter(this);
        }

        public override int GetItemViewType(int position)
        {
            switch (sectionLetterCountries[position])
            {
                case Country _:
                    return TypeName;
                case string _:
                    return TypeLetter;
            }
            return -1;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            switch (holder)
            {
                case CountryViewHolder countryViewHolder:
                    countryViewHolder.Country = (Country)sectionLetterCountries[position];
                    countryViewHolder.ItemClickListener = this;
                    break;
                case HeaderLetterViewHolder headerLetterViewHolder:
                    headerLetterViewHolder.Letter = (string)sectionLetterCountries[position];
                    break;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            switch (viewType)
            {
                case TypeName:
                    var countryNameView = LayoutInflater.From(parent.Context)
                        .Inflate(Resource.Layout.country_item, parent, false);
                    return new CountryViewHolder(countryNameView);
                case TypeLetter:
                    var letterView = LayoutInflater.From(parent.Context)
                        .Inflate(Resource.Layout.header_letter_item, parent, false);
                    return new HeaderLetterViewHolder(letterView);
                default:
                    return null;
            }
        }

        public override int ItemCount => sectionLetterCountries.Count;

        public void OnClick(View itemView, int position)
        {
            Toast.MakeText(context, ((Country) sectionLetterCountries[position]).CountryName, ToastLength.Short).Show();
        }

        public Filter Filter { get; }

        private class CountryFilter : Filter
        {
            private readonly CountryAdapter adapter;

            public CountryFilter(CountryAdapter adapter)
            {
                this.adapter = adapter;
            }

            protected override FilterResults PerformFiltering(ICharSequence constraint)
            {
                var returnObject = new FilterResults();
                var results = new List<Country>();
                if (adapter.originalDatas == null)
                {
                    adapter.originalDatas = adapter.countriesList;
                }
                if (constraint == null) return returnObject;
                if (adapter.originalDatas != null && adapter.originalDatas.Any())
                {
                    results.AddRange(adapter.originalDatas.Where(x =>
                        x.CountryName.ToLower().Contains(constraint.ToString().ToLower())));
                }
                returnObject.Values = FromArray(results.Select(r => r.ToJavaObject()).ToArray());
                returnObject.Count = results.Count;
                constraint.Dispose();
                return returnObject;
            }

            protected override void PublishResults(ICharSequence constraint, FilterResults results)
            {
                using (var values = results.Values)
                {
                    adapter.sectionLetterCountries =
                        GetSectionLetterCountriesList(values.ToArray<Object>()
                            .Select(r => r.ToNetObject<Country>()));
                    adapter.NotifyDataSetChanged();
                    constraint.Dispose();
                    results.Dispose();
                }
            }
        }
    }
}