using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Services
{
    public class ApiService<T> : IApiService<T> where T : class
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiEndpoint;

        public ApiService(HttpClient httpClient, IConfiguration configuration, string entityName)
        {
            _httpClient = httpClient;
            var baseUrl = configuration["ApiSettings:BaseUrl"] ?? "http://localhost:5283";
            _apiEndpoint = $"{baseUrl}/api/{entityName}";
        }

        public async Task<List<T>?> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_apiEndpoint);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<T>>(jsonData);
                }
                return new List<T>();
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiEndpoint}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonData);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> CreateAsync(T entity)
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(entity);
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(_apiEndpoint, stringContent);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(entity);
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(_apiEndpoint, stringContent);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_apiEndpoint}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}