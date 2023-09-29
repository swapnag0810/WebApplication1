using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IThirdPartyHolidayService
    {
        Task<List<ThirdPartyHoliday>> GetHolidays(string countryCode, int year);
    }
}