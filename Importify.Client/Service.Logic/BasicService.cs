using Blazored.LocalStorage;
using Importify.Client.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Importify.Client.Service.Logic
{
    public class BasicService : IBasicService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _storageService;

        public BasicService(IConfiguration configuration, ILocalStorageService storageService)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri($"https://localhost:{configuration["port"]}/api/")
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _storageService = storageService;
        }

        public async Task<List<Country>> GetCountryes()
        {
            var cookieContent = await _storageService.GetItemAsync<string>("access_token");
            _httpClient.DefaultRequestHeaders.Add("access_token", cookieContent);

            var response = await _httpClient.GetAsync("basic/countries");
            var responseString = await response.Content.ReadAsStringAsync();

            var countries = JsonConvert.DeserializeObject<List<Country>>(responseString);

            return countries;
        }
    }
}
