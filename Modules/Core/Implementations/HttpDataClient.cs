using System;
using System.Text.Json;
using Ripple.API.Modules.Core.Interfaces;

namespace Ripple.API.Modules.Core.Implementations
{

    public class HttpDataClient : IHttpDataClient
    {
        private readonly HttpClient httpClient;
        public HttpDataClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;

        }


        public bool IsValidUri(string uri) => Uri.IsWellFormedUriString(uri, UriKind.Absolute);

        public async Task<T> GetAsync<T>(HttpClient httpClient, string requestUrl)
        {
            try
            {
                var response = await httpClient.GetAsync(requestUrl);
                var body = await response.Content.ReadAsStringAsync();
                var queryResponse = JsonSerializer.Deserialize<T>(body, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;
                if (!response.IsSuccessStatusCode) throw new Exception(body);
                return queryResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> PostAsync<T>(HttpClient httpClient, string requestUrl, object data)
        {
            try
            {
                string json = JsonSerializer.Serialize(data);
                StringContent payload = new(json, System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"{requestUrl}", payload);
                var body = await response.Content.ReadAsStringAsync();
                var monnifyResponseDto = JsonSerializer.Deserialize<T>(body, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;
                if (!response.IsSuccessStatusCode) throw new Exception(body);
                return monnifyResponseDto;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> PutAsync<T>(HttpClient httpClient, string requestUrl, object data)
        {
            try
            {
                string json = JsonSerializer.Serialize(data);
                StringContent payload = new(json, System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"{requestUrl}", payload);
                var body = await response.Content.ReadAsStringAsync();
                var monnifyResponseDto = JsonSerializer.Deserialize<T>(body, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;
                if (!response.IsSuccessStatusCode) throw new Exception(body);
                return monnifyResponseDto;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}

