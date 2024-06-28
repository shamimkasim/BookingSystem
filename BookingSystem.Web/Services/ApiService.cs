using BookingSystem.Web.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BookingSystem.Web.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl = "https://localhost:44366/api/";

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<DataModel>> GetAllDataAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<DataModel>>($"{_baseApiUrl}data");
        }

        public async Task<DataModel> GetDataByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<DataModel>($"{_baseApiUrl}data/{id}");
        }

        public async Task CreateDataAsync(DataModel data)
        {
            await _httpClient.PostAsJsonAsync($"{_baseApiUrl}data", data);
        }

        public async Task UpdateDataAsync(int id, DataModel data)
        {
            await _httpClient.PutAsJsonAsync($"{_baseApiUrl}data/{id}", data);
        }

        public async Task DeleteDataAsync(int id)
        {
            await _httpClient.DeleteAsync($"{_baseApiUrl}data/{id}");
        }

        public async Task RegisterUserAsync(UserModel user)
        {
            await _httpClient.PostAsJsonAsync($"{_baseApiUrl}users/register", user);
        }

        public async Task<string> LoginUserAsync(UserModel user)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseApiUrl}users/login", user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}