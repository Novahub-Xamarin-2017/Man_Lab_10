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

        private readonly List<Country> countries;

        private List<Country> originalDatas;

        private static List<object> GetSectionLetterCountriesList(List<Country> countries)
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

        public CountryAdapter(List<Country> countries)
        {
            this.countries = countries ?? new List<Country>();
            sectionLetterCountries = GetSectionLetterCountriesList(this.countries);
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
            var layoutInflater = LayoutInflater.From(parent.Context);
            switch (viewType)
            {
                case TypeName:
                    var countryNameView = layoutInflater.Inflate(Resource.Layout.country_item, parent, false);
                    return new CountryViewHolder(countryNameView);
                case TypeLetter:
                    var letterView = layoutInflater.Inflate(Resource.Layout.header_letter_item, parent, false);
                    return new HeaderLetterViewHolder(letterView);
                default:
                    return null;
            }
        }

        public void SetFilter(List<Country> countries)
        {
            sectionLetterCountries = GetSectionLetterCountriesList(countries);
            NotifyDataSetChanged();
        }

        public override int ItemCount => sectionLetterCountries.Count;

        public void OnClick(View itemView, int position)
        {
            Toast.MakeText(itemView.Context, ((Country) sectionLetterCountries[position]).CountryName, ToastLength.Short).Show();
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
                adapter.originalDatas = adapter.countries;
                if (constraint == null) return returnObject;
                if (adapter.originalDatas != null && adapter.originalDatas.Any())
                {
                    results.AddRange(Country.MatchFilter(adapter.originalDatas, constraint.ToString()));
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
                    adapter.SetFilter(values.ToArray<Object>().Select(r => r.ToNetObject<Country>()).ToList());
                    constraint.Dispose();
                    results.Dispose();
                }
            }
        }
    }
}