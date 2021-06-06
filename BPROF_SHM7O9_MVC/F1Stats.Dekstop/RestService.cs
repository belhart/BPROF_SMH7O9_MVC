﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace F1Stats.Dekstop
{
    public class RestService
    {
        HttpClient client;
        string endpoint;
        string baseurl = "https://f1api.2u.si/";
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
    }
}