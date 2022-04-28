using Blazored.LocalStorage;
using Importify.Client.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Importify.Client.Service.Logic
{
    public class MassageService : IMassageService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _storageService;

        public MassageService(IConfiguration configuration, ILocalStorageService storageService)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri($"https://localhost:{configuration["port"]}/api/")
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _storageService = storageService;
        }

        public async Task<int> AddMassage(Massage massage)
        {
            var response = await _httpClient.PostAsJsonAsync("massage", massage);
            var responseString = await response.Content.ReadAsStringAsync();

            return int.Parse(responseString);
        }

        public async Task<int> DeleteMassage(int id)
        {
            string responseString;

            var cookieContent = await _storageService.GetItemAsync<string>("access_token");

            if (cookieContent is null)
                return -1;

            _httpClient.DefaultRequestHeaders.Remove("access_token");
            _httpClient.DefaultRequestHeaders.Add("access_token", cookieContent);

            var response = await _httpClient.DeleteAsync($"massage/{id}");

            if ((int)response.StatusCode == 401)
            {
                if (await SendRefreshToken(cookieContent) == -1)
                    return -1;

                response = await _httpClient.DeleteAsync($"massage/{id}");

                responseString = await response.Content.ReadAsStringAsync();

                return int.Parse(responseString);
            }

            responseString = await response.Content.ReadAsStringAsync();

            return int.Parse(responseString);
        }

        public async Task<List<Massage>> GetMassages()
        {
            string responseString;
            List<Massage> massages;

            var cookieContent = await _storageService.GetItemAsync<string>("access_token");

            if (cookieContent is null)
                return null;

            _httpClient.DefaultRequestHeaders.Remove("access_token");
            _httpClient.DefaultRequestHeaders.Add("access_token", cookieContent);

            var response = await _httpClient.GetAsync("massage");

            if ((int)response.StatusCode == 401)
            {
                if (await SendRefreshToken(cookieContent) == -1)
                    return null;

                response = await _httpClient.GetAsync("massage");

                responseString = await response.Content.ReadAsStringAsync();
                massages = JsonConvert.DeserializeObject<List<Massage>>(responseString);

                return massages;
            }

            responseString = await response.Content.ReadAsStringAsync();
            massages = JsonConvert.DeserializeObject<List<Massage>>(responseString);

            return massages;
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

            await _storageService.SetItemAsStringAsync("access_token", tokens.AccessToken);
            await _storageService.SetItemAsStringAsync("refresh_token", tokens.RefreshToken);

            cookieContent = await _storageService.GetItemAsync<string>("access_token");
            _httpClient.DefaultRequestHeaders.Remove("access_token");
            _httpClient.DefaultRequestHeaders.Add("access_token", cookieContent);

            return 0;
        }
    }
}
