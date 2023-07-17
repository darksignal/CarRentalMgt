using CarRentalMgt.Client.Contracts;
using System.Net.Http.Json;

namespace CarRentalMgt.Client.Services
{
    public class HttpRepository<T> : IDisposable, IHttpRepository<T> where T : class
    {
        private readonly HttpClient _client;
        private readonly HttpInterceptorService _interceptor;

        public HttpRepository(HttpClient client, HttpInterceptorService interceptor)
        {
            _client = client;
            _interceptor = interceptor;
        }
        public async Task Create(string url, T obj)
        {
            _interceptor.MonitorEvent();
            await _client.PostAsJsonAsync(url, obj);
        }

        public async Task Delete(string url, int id)
        {
            _interceptor.MonitorEvent();
            await _client.DeleteAsync($"{url}/{id}");
        }

        public void Dispose()
        {
            _interceptor.DisposeEvent();
        }

        public async Task<T> Get(string url, int id)
        {
            _interceptor.MonitorEvent();
            return await _client.GetFromJsonAsync<T>($"{url}/{id}");
        }

        public async Task<IList<T>> GetAll(string url)
        {
            _interceptor.MonitorEvent();
            return await _client.GetFromJsonAsync<IList<T>>($"{url}");
        }

        public async Task Update(string url, T obj, int id)
        {
            _interceptor.MonitorEvent();
            await _client.PutAsJsonAsync($"{url}/{id}", obj);
        }


    }
}
