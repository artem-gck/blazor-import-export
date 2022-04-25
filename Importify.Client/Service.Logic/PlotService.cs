using Blazored.LocalStorage;
using Importify.Client.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

using System.Security.Claims;
using System.Text;

namespace Importify.Client.Service.Logic
{
    public class PlotService : IPlotService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _storageService;

        public PlotService(IConfiguration configuration, ILocalStorageService storageService)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri($"https://localhost:{configuration["port"]}/api/")
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _storageService = storageService;
        }

        public async Task<List<CountryConstituent>> GetCountryConstituentAsync(string country, int year)
        {
            string responseString;
            List<CountryConstituent> countryConstituent;

            var cookieContent = await _storageService.GetItemAsync<string>("access_token");

            if (cookieContent is null)
                return null;

            _httpClient.DefaultRequestHeaders.Remove("access_token");
            _httpClient.DefaultRequestHeaders.Add("access_token", cookieContent);

            var response = await _httpClient.GetAsync($"plot/share/{country}/{year}");

            if ((int)response.StatusCode == 401)
            {
                if (await SendRefreshToken(cookieContent) == -1)
                    return null;

                response = await _httpClient.GetAsync($"plot/share/{country}/{year}");

                responseString = await response.Content.ReadAsStringAsync();
                countryConstituent = JsonConvert.DeserializeObject<List<CountryConstituent>>(responseString);

                return countryConstituent;
            }

            responseString = await response.Content.ReadAsStringAsync();
            countryConstituent = JsonConvert.DeserializeObject<List<CountryConstituent>>(responseString);

            return countryConstituent;
        }

        public async Task<List<CountryConstituent>> GetCountryConstituentExportAsync(string country)
        {
            string responseString;
            List<CountryConstituent> countryConstituent;

            var cookieContent = await _storageService.GetItemAsync<string>("access_token");

            if (cookieContent is null)
                return null;

            _httpClient.DefaultRequestHeaders.Remove("access_token");
            _httpClient.DefaultRequestHeaders.Add("access_token", cookieContent);

            var response = await _httpClient.GetAsync($"plot/countryconstituent/{country}");

            if ((int)response.StatusCode == 401)
            {
                if (await SendRefreshToken(cookieContent) == -1)
                    return null;

                response = await _httpClient.GetAsync($"plot/countryconstituent/{country}");

                responseString = await response.Content.ReadAsStringAsync();
                countryConstituent = JsonConvert.DeserializeObject<List<CountryConstituent>>(responseString);

                return countryConstituent;
            }

            responseString = await response.Content.ReadAsStringAsync();
            countryConstituent = JsonConvert.DeserializeObject<List<CountryConstituent>>(responseString);

            return countryConstituent;
        }

        public async Task<List<CountryImportExport>> GetCountryImportExportAsync(string country)
        {
            string responseString;
            List<CountryImportExport> countryImportExport;

            var cookieContent = await _storageService.GetItemAsync<string>("access_token");

            if (cookieContent is null)
                return null;

            _httpClient.DefaultRequestHeaders.Remove("access_token");
            _httpClient.DefaultRequestHeaders.Add("access_token", cookieContent);

            var response = await _httpClient.GetAsync($"plot/all/{country}");

            if ((int)response.StatusCode == 401)
            {
                if (await SendRefreshToken(cookieContent) == -1)
                    return null;

                response = await _httpClient.GetAsync($"plot/all/{country}");

                responseString = await response.Content.ReadAsStringAsync();
                countryImportExport = JsonConvert.DeserializeObject<List<CountryImportExport>>(responseString);

                return countryImportExport;
            }

            responseString = await response.Content.ReadAsStringAsync();
            countryImportExport = JsonConvert.DeserializeObject<List<CountryImportExport>>(responseString);

            return countryImportExport;
        }

        private async Task<int> SendRefreshToken(string cookieContent)
        {
            var tok = new Tokens()
            {
                AccessToken = cookieContent,
                RefreshToken = await _storageService.GetItemAsync<string>("refresh_token"),
            };

            var resp = await _httpClient.PostAsJsonAsync("token/refresh", tok);

            if ((int)resp.StatusCode == 404)
                return -1;

            var respString = await resp.Content.ReadAsStringAsync();
            var tokens = JsonConvert.DeserializeObject<Tokens>(respString);

            _httpClient.DefaultRequestHeaders.Remove("access_token");
            _httpClient.DefaultRequestHeaders.Remove("refresh_token");
            await _storageService.SetItemAsStringAsync("access_token", tokens.AccessToken);
            await _storageService.SetItemAsStringAsync("refresh_token", tokens.RefreshToken);

            cookieContent = await _storageService.GetItemAsync<string>("access_token");
            _httpClient.DefaultRequestHeaders.Remove("access_token");
            _httpClient.DefaultRequestHeaders.Add("access_token", cookieContent);

            return 0;
        }
    }
}
