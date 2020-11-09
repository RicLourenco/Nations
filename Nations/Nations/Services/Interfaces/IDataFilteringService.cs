using System;
using System.Collections.Generic;
using System.Text;

namespace Nations.Services.Interfaces
{
    public interface IDataFilteringService
    {
        string CheckString(string property);

        List<string> CheckStringList(List<string> property);
    }
}
