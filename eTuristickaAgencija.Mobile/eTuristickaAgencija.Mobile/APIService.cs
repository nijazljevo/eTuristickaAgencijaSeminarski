/* using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eProdaja.Model;
using Flurl.Http;
using Flurl;
using Xamarin.Forms;

namespace eProdaja.Mobile
{
    public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        public string _route = null;

#if DEBUG
        //private string _apiUrl = "https://localhost:44396/api"; //sa ssl
        //private string _apiUrl2 = "http://localhost:51097/api";
        private string _apiUrl2 = "http://localhost:5000/api";
#endif

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {
            var url = $"{_apiUrl2}/{_route}";

            try
            {
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                 if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    //MessageBox.Show("Niste authentificirani");
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste authentificirani", "OK");
                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.NotFound)
                {
                    //MessageBox.Show("Niste authentificirani");
                    await Application.Current.MainPage.DisplayAlert("Greška", "Nista nije pronadjeno", "OK");
                }
                throw ex;
            }
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{_apiUrl2}/{_route}/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{_apiUrl2}/{_route}";

            
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            
            

        }

        public async Task<T> Update<T>(int id, object request)
        {
            //try
            //{
                var url = $"{_apiUrl2}/{_route}/{id}";

                 var result= await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            return result;
               
            //}

            //catch (FlurlHttpException ex)
            //{
            //    var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

            //    var stringBuilder = new StringBuilder();
            //    foreach (var error in errors)
            //    {
            //        stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
            //    }

            //    await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");
            //    return default(T);
            //}

        }

        public async Task<bool> Delete<T>(int id)
        {
            var url = $"{_apiUrl2}/{_route}/{id}";
            return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<bool>();
        }
    }
}*/