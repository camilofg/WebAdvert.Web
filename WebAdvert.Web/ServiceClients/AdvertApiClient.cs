using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AdvertApi.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace WebAdvert.Web.ServiceClients
{
    public class AdvertApiClient : IAdvertApiClient
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _client;

        public AdvertApiClient(IConfiguration configuration, HttpClient client)
        {
            _configuration = configuration;
            _client = client;

            var baseUrl = _configuration.GetSection("AdvertApi").GetValue<string>("Url");
            _client.BaseAddress = new Uri(baseUrl);
            _client.DefaultRequestHeaders.Add("Content-type", "application/json");
        }

        public async Task<CreateAdvertResponse> Create(AdvertModel model)
        {
            //var advertApiModel = new AdvertModel();//automapper 
            var jsonModel = JsonConvert.SerializeObject(model);
            var response = await _client.PostAsync(new Uri($"{_client.BaseAddress}/create"), new StringContent(jsonModel));
            var responseJson = await response.Content.ReadAsStringAsync();
            var createAdvertResponse = JsonConvert.DeserializeObject<CreateAdvertResponse>(responseJson);
            //var advertResponse = new CreateAdvertResponse(); //automapper

            return createAdvertResponse;
        }

        public async Task<bool> Confirm(AdvertConfirmModel model)
        {
            var jsonModel = JsonConvert.SerializeObject(model);
            var response =
                await _client.PostAsync(new Uri($"{_client.BaseAddress}/Confirm"), new StringContent(jsonModel));
            return response.StatusCode == HttpStatusCode.OK;


        }
    }
}
