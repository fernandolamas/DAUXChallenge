using DauxChallengeCommon.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace DauxChallengeService.Services.EncryptService
{
    public class EncryptService : IEncryptService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public EncryptService(IHttpClientFactory httpClientFactory) { 
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> EncryptAsync(IdentityViewModel identity)
        {
            try
            {
                string toEncrypt = identity.Firstname + identity.Lastname;
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(toEncrypt);
                var encrypt = Convert.ToBase64String(plainTextBytes);

                var httpClient = _httpClientFactory.CreateClient();
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization",encrypt);

                string json = JsonConvert.SerializeObject(identity);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(new Uri("https://daux.com.ar/api/test-encrypt"), content);
                if(response.IsSuccessStatusCode)
                {
                    EncryptServiceResponse? obj = await response.Content.ReadFromJsonAsync<EncryptServiceResponse>();
                    return obj!.Result;
                }
                return "Server not responding, try again later.";
            }catch
            {
                throw;
            }
        }
    }
}
