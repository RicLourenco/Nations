using Nations.Models;
using Nations.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nations.Services.Classes
{

    public class ApiService : IApiService
    {
        public async Task<Response> GetCountriesAsync<T>(string urlBase, string controller)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var response = await client.GetAsync(controller);

                var result = await response.Content.ReadAsStringAsync();


                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result
                    };
                }

                var countries = JsonConvert.DeserializeObject<List<T>>(result, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

                //DownloadFlags(countries);

                //await ConvertFlags(countries);

                return new Response
                {
                    IsSuccess = true,
                    Result = countries
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }


        //public async Task ConvertFlags(List<Country> countries)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DownloadFlags(List<Country> countries)
        //{
        //    if (!Directory.Exists("Flags"))
        //    {
        //        Directory.CreateDirectory("Flags");
        //    }

        //    foreach (var country in countries)
        //    {
        //        try
        //        {
        //            using (var flag = new WebClient())
        //            {
        //                flag.DownloadFileAsync(country.Flag, $@"Flags\{country.Name}.svg");
        //            }
        //        }
        //        catch (Exception e)
        //        {

        //        }
        //    }

        //    try
        //    {
        //        var noFlag = new WebClient();

        //        noFlag.DownloadFile("https://upload.wikimedia.org/wikipedia/commons/b/b0/No_flag.svg", $@"Flags\Default.svg");

        //        noFlag.Dispose();
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}
    }
}
