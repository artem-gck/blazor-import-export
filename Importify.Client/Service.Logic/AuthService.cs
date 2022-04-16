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

        public AuthService(IConfiguration configuration)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri($"https://localhost:{configuration["port"]}/api/")
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Tokens> Login(LoginUser user)
        {
            var response = await _httpClient.PostAsJsonAsync("authentication/login", user);
            var tokensString = await response.Content.ReadAsStringAsync();
            
            var tokens = JsonConvert.DeserializeObject<Tokens>(tokensString);

            return tokens;
        }


    }
}
