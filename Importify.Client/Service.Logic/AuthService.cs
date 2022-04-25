using Blazored.LocalStorage;
using Importify.Client.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;

namespace Importify.Client.Service.Logic
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _storageService;

        public AuthService(IConfiguration configuration, ILocalStorageService storageService)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri($"https://localhost:{configuration["port"]}/api/")
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _storageService = storageService;
        }

        public async Task<Tokens> Login(LoginUser user)
        {
            var response = await _httpClient.PostAsJsonAsync("authentication/login", user);
            var tokensString = await response.Content.ReadAsStringAsync();
            
            var tokens = JsonConvert.DeserializeObject<Tokens>(tokensString);

            await _storageService.SetItemAsStringAsync("user", tokens.Login);
            await _storageService.SetItemAsStringAsync("role", tokens.Role);

            return tokens;
        }

        public async Task<int> Registration(RegistrationUser user)
        {
            var response = await _httpClient.PostAsJsonAsync("authentication", user);
            var responseString = await response.Content.ReadAsStringAsync();

            if (int.TryParse(responseString, out int idOfUser))
                return idOfUser;
            else
                return -1;
        }
    }
}
