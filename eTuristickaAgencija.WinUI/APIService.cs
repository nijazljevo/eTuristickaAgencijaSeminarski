using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTuristickaAgencija.Models;
using eProdaja.Model;

namespace eTuristickaAgencija.WinUI
{
    public class APIService
    {
        public string _route = null;
        public static string Username { get; set; }
        public static string Password { get; set; }
        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {
            
            //var url = $"{Properties.Settings.Default.APIUrl}/{_route}";
            var url = $"{Properties.Settings.Default.APIUrl2}/{_route}";
            if (search!=null)
            {
                url += "?";
                url +=  await search.ToQueryString();
            }
            var result = await url.WithBasicAuth(Username,Password).GetJsonAsync<T>();
            return result;
        }
        public async Task<T> GetById<T>(object id)
        {

            //var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";
            var url = $"{Properties.Settings.Default.APIUrl2}/{_route}/{id}";

            var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            return result;
        }
        public async Task<T> Insert<T>(object request)
        {

            //var url = $"{Properties.Settings.Default.APIUrl}/{_route}";
            var url = $"{Properties.Settings.Default.APIUrl2}/{_route}";
            var result = await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            return result;
        }
        public async Task<T> Update<T>(object id,object request)
        {

            //var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";
            var url = $"{Properties.Settings.Default.APIUrl2}/{_route}/{id}";

            var result = await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            return result;
        }

        public async Task<bool> Delete<T>(object id)
        {

            //var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";
            var url = $"{Properties.Settings.Default.APIUrl2}/{_route}/{id}";

            var result = await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<bool>();
            return result;
        }


    }
}
