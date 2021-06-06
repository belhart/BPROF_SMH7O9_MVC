using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace F1Stats.Dekstop
{
    public class RestService
    {
        HttpClient client;
        string endpoint = "https://api.android.2u.si/";
        public RestService(string baseurl, string endpoint, string token = "")
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
        }
    }
}
