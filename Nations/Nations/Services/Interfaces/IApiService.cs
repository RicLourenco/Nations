using Nations.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nations.Services.Interfaces
{
    public interface IApiService
    {
        Task<Response> GetCountriesAsync<T>(string urlBase, string controller);
    }
}
