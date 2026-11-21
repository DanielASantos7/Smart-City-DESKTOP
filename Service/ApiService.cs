using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MundialDESKTOP.V1.Service
{
    public static class ApiService
    {

        public static readonly HttpClient Http = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5215/"),
        };

        public static void SetToken(string token)
        {
            Http.DefaultRequestHeaders.Remove("Authorization");
            if (!string.IsNullOrWhiteSpace(token))
                Http.DefaultRequestHeaders.Add("Authorization", token);
        }

        private static async Task<T> SendAsync<T>(HttpMethod method, string endpoint, object data = null)
        {
            try
            {
                var req = new HttpRequestMessage(method, endpoint);
                if (data != null)
                    req.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                var res = await Http.SendAsync(req);
                res.EnsureSuccessStatusCode();

                var json = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message);
                return default;
            }
        }


        public static Task<T> GetTAsync<T>(string endpoint) => SendAsync<T>(HttpMethod.Get, endpoint);
        public static Task<T> PostAsync<T>(string endpoint, object data = null) => SendAsync<T>(HttpMethod.Post, endpoint, data);
        public static Task<T> PutAsync<T>(string endpoint, object data = null) => SendAsync<T>(HttpMethod.Put, endpoint, data);
        public static Task<T> PatchAsync<T>(string endpoint, object data = null) => SendAsync<T>(new HttpMethod("PATCH"), endpoint, data);
        public static Task DeleteAsync(string endpoint, object data = null) => SendAsync<object>(HttpMethod.Delete, endpoint, data);
    }
}
