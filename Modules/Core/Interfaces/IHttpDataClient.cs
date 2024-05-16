using System;
namespace FormBuilder.Modules.Core.Interfaces
{
    public interface IHttpDataClient
    {
        Task<T> PostAsync<T>(HttpClient httpClient, string requestUrl, object data);
        Task<T> PutAsync<T>(HttpClient httpClient, string requestUrl, object data);
        Task<T> GetAsync<T>(HttpClient httpClient, string requestUrl);
        bool IsValidUri(string uri);
    }
}

