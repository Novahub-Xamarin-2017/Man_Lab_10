using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Exercise_7.Models;

namespace Exercise_7.Adapters
{
    public class CountryAdapter : RecyclerView.Adapter
    {
        private const int TypeName = 1;

        private const int TypeLetter = 2;

        private List<Country> countries;

        private List<object> countriesWithHeaderLetter;

        private void GetCountriesWithHeaderLetterList()
        {
            countriesWithHeaderLetter = new List<object>();
          
        }
        public CountryAdapter(List<Country> countries)
        {
            this.countries = countries;
        }

        public override int GetItemViewType(int position)
        {
            switch (countriesWithHeaderLetter[position])
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
            var viewType = holder.ItemViewType;
            switch (viewType)
            {
                case TypeName:
                    ((CountryViewHolder) holder).Country = (Country)countriesWithHeaderLetter[position];
                    break;
                case TypeLetter:
                    ((HeaderLetterViewHolder)holder).Letter = (string)countriesWithHeaderLetter[position];
                    break;
                default:
                    return;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            RecyclerView.ViewHolder viewHolder;
            switch (viewType)
            {
                case TypeName:
                    var countryNameView = LayoutInflater.From(parent.Context)
                        .Inflate(Resource.Layout.country_item, parent, false);
                    viewHolder = new CountryViewHolder(countryNameView);
                    break;
                case TypeLetter:
                    var letterView = LayoutInflater.From(parent.Context)
                        .Inflate(Resource.Layout.header_letter_item, parent, false);
                    viewHolder = new HeaderLetterViewHolder(letterView);
                    break;
                default:
                    viewHolder = null;
                    break;
            }
            return viewHolder;
        }

        public override int ItemCount => countriesWithHeaderLetter.Count;
    }
}