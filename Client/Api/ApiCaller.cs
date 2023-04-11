namespace TicketHiveSpaceKittens.Client.Api
{
    public class ApiCaller
    {
        public async Task MakeCallAsync()
        {
            string accessKey = "XaulSyIDQ0phVPhVF9UoXoezIzxKdpu2";

            HttpResponseMessage response = await ApiInitializer.httpClient.GetAsync(accessKey);

            if (response.IsSuccessStatusCode)
            {
                var responseStr = await response.Content.ReadAsStringAsync();

                var fisk = 1;
            }
            //sätta basadress i program.cs
        }
    }
}
