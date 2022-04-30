using Blazored.LocalStorage;
using Importify.Client.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

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

        public async Task<List<Category>> GetCategories()
        {
            string responseString;
            List<Category> categories;

            var cookieContent = await _storageService.GetItemAsync<string>("access_token");

            if (cookieContent is null)
                return null;

            _httpClient.DefaultRequestHeaders.Remove("access_token");
            _httpClient.DefaultRequestHeaders.Add("access_token", cookieContent);

            var response = await _httpClient.GetAsync("basic/categories");

            if ((int)response.StatusCode == 401)
            {
                if (await SendRefreshToken(cookieContent) == -1)
                    return null;

                response = await _httpClient.GetAsync("basic/categories");

                responseString = await response.Content.ReadAsStringAsync();
                categories = JsonConvert.DeserializeObject<List<Category>>(responseString);

                return categories;
            }

            responseString = await response.Content.ReadAsStringAsync();
            categories = JsonConvert.DeserializeObject<List<Category>>(responseString);

            return categories;
        }

        public async Task<List<Country>> GetCountryes()
        {
            string responseString;
            List<Country> countries;

            var cookieContent = await _storageService.GetItemAsync<string>("access_token");
            
            if (cookieContent is null)
                return null;

            _httpClient.DefaultRequestHeaders.Remove("access_token");
            _httpClient.DefaultRequestHeaders.Add("access_token", cookieContent);

            var response = await _httpClient.GetAsync("basic/countries");

            if ((int)response.StatusCode == 401)
            {
                if (await SendRefreshToken(cookieContent) == -1)
                    return null;

                response = await _httpClient.GetAsync("basic/countries");

                responseString = await response.Content.ReadAsStringAsync();
                countries = JsonConvert.DeserializeObject<List<Country>>(responseString);

                return countries;
            }

            responseString = await response.Content.ReadAsStringAsync();
            countries = JsonConvert.DeserializeObject<List<Country>>(responseString);

            return countries;
        }

        public async Task<List<Year>> GetYears()
        {
            string responseString;
            List<Year> years;

            var cookieContent = await _storageService.GetItemAsync<string>("access_token");

            if (cookieContent is null)
                return null;

            _httpClient.DefaultRequestHeaders.Remove("access_token");
            _httpClient.DefaultRequestHeaders.Add("access_token", cookieContent);

            var response = await _httpClient.GetAsync("basic/years");

            if ((int)response.StatusCode == 401)
            {
                if (await SendRefreshToken(cookieContent) == -1)
                    return null;

                response = await _httpClient.GetAsync("basic/years");

                responseString = await response.Content.ReadAsStringAsync();
                years = JsonConvert.DeserializeObject<List<Year>>(responseString);

                return years;
            }

            responseString = await response.Content.ReadAsStringAsync();
            years = JsonConvert.DeserializeObject<List<Year>>(responseString);

            return years;
        }

        private async Task<int> SendRefreshToken(string cookieContent)
        {
            var tok = new Tokens()
            {
                AccessToken = cookieContent,
                RefreshToken = await _storageService.GetItemAsync<string>("refresh_token"),
                Login = await _storageService.GetItemAsync<string>("user"),
                Role = await _storageService.GetItemAsync<string>("role")
            };

            var resp = await _httpClient.PostAsJsonAsync("token/refresh", tok);

            if ((int)resp.StatusCode == 400)
                return -1;

            var respString = await resp.Content.ReadAsStringAsync();
            var tokens = JsonConvert.DeserializeObject<Tokens>(respString);

            await _storageService.SetItemAsStringAsync("access_token", tokens.AccessToken);
            await _storageService.SetItemAsStringAsync("refresh_token", tokens.RefreshToken);

            cookieContent = await _storageService.GetItemAsync<string>("access_token");
            _httpClient.DefaultRequestHeaders.Remove("access_token");
            _httpClient.DefaultRequestHeaders.Add("access_token", cookieContent);

            return 0;
        }
    }
}
