using Newtonsoft.Json;

namespace TicketHiveSpaceKittens.Shared.Models
{
    // JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Rates
    {
        [JsonProperty("EUR")]
        public double? EUR { get; set; }

        [JsonProperty("GBP")]
        public double? GBP { get; set; }

    }

    public class Root
    {
        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("rates")]
        public Rates Rates { get; set; }

        [JsonProperty("success")]
        public bool? Success { get; set; }

        [JsonProperty("timestamp")]
        public int? Timestamp { get; set; }
    }


}
