using Nations.Models;
using Nations.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nations.Services.Classes
{
    public class DataFilteringService : IDataFilteringService
    {
        public string CheckString(string prop) =>
            string.IsNullOrEmpty(prop) ? "N/A" : prop;

        public List<string> CheckListOfStrings(List<string> list)
        {
            if(list.Count == 0)
            {
                list.Add("N/A");
            }

            return list;
        }

        public List<RegionalBloc> CheckRegionalBlocsList(List<RegionalBloc> regionalBlocs)
        {
            foreach(var regionalBloc in regionalBlocs)
            {
                regionalBloc.Name = CheckString(regionalBloc.Name);
                regionalBloc.Acronym = CheckString(regionalBloc.Acronym);
                regionalBloc.OtherAcronyms = CheckListOfStrings(regionalBloc.OtherAcronyms);
                regionalBloc.OtherNames = CheckListOfStrings(regionalBloc.OtherNames);
            }

            return regionalBlocs;
        }
    }
}
