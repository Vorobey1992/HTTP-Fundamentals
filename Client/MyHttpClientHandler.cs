using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    public class MyHttpClientHandler
    {
        private readonly HttpClient _httpClient;

        public MyHttpClientHandler()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetMyNameAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:8888/MyName/");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return "Error while retrieving data.";
            }
        }

        public async Task<string> GetInformationAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:8888/Information/");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return "Error while retrieving data.";
            }
        }

        public async Task<string> GetStatusCodeAsync(string path)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"http://localhost:8888/{path}/");

            if (response.IsSuccessStatusCode)
            {
                return $"Status code: {response.StatusCode}";
            }
            else
            {
                return $"Status code: {response.StatusCode}";
            }
        }

        public async Task<string> GetNameFromHeaderAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:8888/MyNameByHeader/");

            if (response.IsSuccessStatusCode)
            {
                if (response.Headers.TryGetValues("X-Response-Header", out var values))
                {
                    return $"Name from header: {values.FirstOrDefault()}";
                }
                else
                {
                    return "Header not found.";
                }
            }
            else
            {
                return "Error while retrieving data.";
            }
        }

        public async Task<string> GetNameFromCookieAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:8888/MyNameByCookies/");

            if (response.IsSuccessStatusCode)
            {
                if (response.Headers.TryGetValues("Set-Cookie", out var values))
                {
                    var cookie = values.FirstOrDefault()?.Split(';')[0]?.Split('=')[1];
                    if (!string.IsNullOrEmpty(cookie))
                    {
                        return $"Name from cookie: {cookie}";
                    }
                    else
                    {
                        return "Cookies not found.";
                    }
                }
                else
                {
                    return "Cookies not found.";
                }
            }
            else
            {
                return "Error while retrieving data.";
            }
        }
    }
}
