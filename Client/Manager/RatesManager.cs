using TicketHiveSpaceKittens.Client.Api;

namespace TicketHiveSpaceKittens.Client.Manager
{
    public static class RatesManager
    {
        public static decimal EUR { get; set; } = 0.08m;
        public static decimal GBP { get; set; } = 0.09m;
        public static string DisplayRate { get; set; } = "EUR";

        public static string GetPrice(decimal value)
        {
            string returnMsg = "";
            if (DisplayRate == "GBP")
            {
                returnMsg = decimal.Round(value * GBP, 2, MidpointRounding.AwayFromZero).ToString() + " £";
            }
            else if (DisplayRate == "EUR")
            {
                returnMsg = decimal.Round(value * EUR, 2, MidpointRounding.AwayFromZero).ToString() + " €";
            }
            else
            {
                returnMsg = (value).ToString() + " SEK";
            }
            return returnMsg;
        }

        public static void CheckRates(string userCountry)
        {
            if (userCountry == "Great_Britain")
            {
                DisplayRate = "GBP";
            }
            else if (userCountry == "Sweden")
            {
                DisplayRate = "SEK";
            }
            else
            {
                DisplayRate = "EUR";
            }
        }

        public static async Task ApiCallForRates()
        {
            ApiCaller apiCaller = new();
            await apiCaller.MakeCallAsync();
        }
    }
}
