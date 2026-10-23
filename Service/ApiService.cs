using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            Timeout = TimeSpan.FromSeconds(10)
        };

        public static async Task<T> GetAsync<T>(string endpoint)
        {
            try
            {
                string json = await Http.GetStringAsync(endpoint);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ERRO GET]: " + ex.Message);
                return default(T);
            }
        }

        public static async Task<TResponse> PostAsync<TResponse>(string endpoint, object data = null)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                var response = await Http.PostAsync(endpoint, content);
                var json = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(JObject.Parse(json)["message"]?.ToString() ??
                        "Erro desconhecido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return default(TResponse);
                }

                return JsonConvert.DeserializeObject<TResponse>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                return default(TResponse);
            }
        }

        public static async Task<TResponse> PatchAsync<TResponse>(string endpoint, object data = null)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(new HttpMethod("PATCH"), endpoint) { Content = content };
                var response = await Http.SendAsync(request);
                var json = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(JObject.Parse(json)["message"]?.ToString() ??
                        "Erro desconhecido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return default(TResponse);
                }

                return JsonConvert.DeserializeObject<TResponse>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                return default(TResponse);
            }
        }
    }
}
