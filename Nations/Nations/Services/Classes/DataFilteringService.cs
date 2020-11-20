using Nations.Models;
using Nations.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nations.Services.Classes
{
    public class DataFilteringService : IDataFilteringService
    {
        public string CheckString(string prop)
        {
            //if (string.IsNullOrEmpty(prop))
            //{
            //    return "N/A";
            //}

            //return prop;

            return string.IsNullOrEmpty(prop) ? "N/A" : prop;
        }

        public List<string> CheckListOfStrings(List<string> list)
        {
            if(list.Count == 0)
            {
                list.Add("N/A");
            }

            return list;
        }

        public List<RegionalBloc> CheckRegionalBlocsList(List<RegionalBloc> list)
        {
            foreach(var rb in list)
            {
                rb.Name = CheckString(rb.Name);
                rb.Acronym = CheckString(rb.Acronym);
                rb.OtherAcronyms = CheckListOfStrings(rb.OtherAcronyms);
                rb.OtherNames = CheckListOfStrings(rb.OtherNames);
            }

            return list;
        }
    }
}
