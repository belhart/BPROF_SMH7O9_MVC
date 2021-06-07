using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace F1Stats.Dekstop
{
    public class RestService
    {
        HttpClient client;
        string endpoint;
        string baseurl = "https://apif1.2u.si/";
        public RestService(string endpoint, string token = "")
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri(baseurl);
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue
                ("application/json"));

            if (token != "")
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            this.endpoint = endpoint;
        }

        public async void Post<T>(T item)
        {
            HttpResponseMessage response =
                await client.PostAsJsonAsync(endpoint, item);

            response.EnsureSuccessStatusCode();
        }

        public async Task<R> Put<R, T>(T item)
        {
            HttpResponseMessage response =
                await client.PutAsJsonAsync(endpoint + "/", item);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<R>();
        }

        public async Task<List<T>> Get<T>()
        {
            List<T> items = new List<T>();
            HttpResponseMessage response = await
                client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                items = await response.Content.ReadAsAsync<List<T>>();
            }
            return items;
        }
    }
}
