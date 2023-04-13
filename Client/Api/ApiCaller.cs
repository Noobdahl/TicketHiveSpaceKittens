using Newtonsoft.Json;
using TicketHiveSpaceKittens.Client.Manager;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Client.Api
{
    public class ApiCaller
    {
        public async Task MakeCallAsync()
        {
            string fullURL = "https://api.apilayer.com/exchangerates_data/latest?symbols=EUR,GBP&base=SEK";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, fullURL);

            request.Headers.Add("apikey", "XaulSyIDQ0phVPhVF9UoXoezIzxKdpu2");

            HttpResponseMessage response = await ApiInitializer.httpClient.SendAsync(request);

            var responseStr = await response.Content.ReadAsStringAsync();

            Root? result = JsonConvert.DeserializeObject<Root>(responseStr);

            RatesManager.GBP = (decimal)result.Rates.GBP;
            RatesManager.EUR = (decimal)result.Rates.EUR;
        }
    }
}
