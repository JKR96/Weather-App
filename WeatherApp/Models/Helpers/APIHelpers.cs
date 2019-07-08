using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp.Models.Helpers
{
    public static class APIHelpers
    {
        private const int TIMEOUT_SECONDS = 10;
        public static string Token { get; set; } = string.Empty;

        public static async Task<T> Get<T>(string address)
        {
            try
            {
                HttpClient client = new HttpClient { Timeout = TimeSpan.FromSeconds(TIMEOUT_SECONDS) };
                HttpResponseMessage response = await client.GetAsync(new Uri(address));
                string responseJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseJson);
            }
            catch (Exception) { return default(T); }
        }

        //public static async Task<T> Post<T>(string address, object content)
        //{
        //    try
        //    {
        //        string requestJson = JsonConvert.SerializeObject(content);
        //        StringContent stringContent = new StringContent(
        //            requestJson,
        //            Encoding.UTF8,
        //            "application/json");
        //        HttpClient client = new HttpClient() { Timeout = TimeSpan.FromSeconds(TIMEOUT_SECONDS) };
        //        HttpResponseMessage response = await client.PostAsync(new Uri(address), stringContent);
        //        string responseJson = await response.Content.ReadAsStringAsync();
        //        return JsonConvert.DeserializeObject<T>(responseJson);
        //    }
        //    catch (Exception) { return default(T); }
        //}

        //public static async Task<T> Put<T>(string address, object content)
        //{
        //    try
        //    {
        //        string requestJson = JsonConvert.SerializeObject(content);
        //        StringContent stringContent = new StringContent(
        //            requestJson,
        //            Encoding.UTF8,
        //            "application/json");
        //        HttpClient client = new HttpClient();
        //        HttpResponseMessage response = await client.PutAsync(new Uri(address), stringContent);
        //        string responseJson = await response.Content.ReadAsStringAsync();
        //        return JsonConvert.DeserializeObject<T>(responseJson);
        //    }
        //    catch (Exception) { return default(T); }
        //}

        //public static bool CheckResponse(ResponseDTO response)
        //{
        //    return response != null
        //        && response.ErrorCode == null;
        //}
    }
}
