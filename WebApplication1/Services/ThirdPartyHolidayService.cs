using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ThirdPartyHolidayService : IThirdPartyHolidayService
    {
        private static readonly HttpClient client;

        static ThirdPartyHolidayService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://date.nager.at")
            };
            //client = clientFactory.CreateClient("PublicHolidaysApi");
        }

        public async Task<List<ThirdPartyHoliday>> GetHolidays(string countryCode, int year)
        {
            var url = string.Format("/api/v2/PublicHolidays/{0}/{1}", year, countryCode);
            var result = new List<ThirdPartyHoliday>();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<List<ThirdPartyHoliday>>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}