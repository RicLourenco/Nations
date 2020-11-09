using Nations.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nations.Services.Classes
{
    public class DataFilteringService : IDataFilteringService
    {
        public string CheckString(string property)
        {
            if (!string.IsNullOrEmpty(property))
            {
                return property;
            }

            return "N/A";
        }

        public List<string> CheckStringList(List<string> propertiesList)
        {
            if(propertiesList.Count == 0)
            {
                propertiesList.Add("N/A");

                return propertiesList;
            }

            return propertiesList;
        }
    }
}
