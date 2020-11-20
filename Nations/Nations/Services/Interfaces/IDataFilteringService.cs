using Nations.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nations.Services.Interfaces
{
    public interface IDataFilteringService
    {
        string CheckString(string prop);

        List<string> CheckListOfStrings(List<string> list);

        List<RegionalBloc> CheckRegionalBlocsList(List<RegionalBloc> list);
    }
}
