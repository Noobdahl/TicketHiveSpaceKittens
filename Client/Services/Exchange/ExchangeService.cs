namespace TicketHiveSpaceKittens.Client.Services.Exchange
{
    public class ExchangeService : IExchangeService
    {
        private readonly HttpClient httpClient;

        public ExchangeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task GetRates()
        {
            var response = await httpClient.GetAsync("https://api.exchangeratesapi.io/v1/");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var fisk = 1;
                //return JsonConvert.DeserializeObject<>>(json);
            }
        }
    }
}
