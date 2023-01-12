using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text.Json;
using WebAPICalendar.DataContract;

namespace WebAPICalendar.DataClient;

public class CalendarDataClient : ICalendarDataClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public CalendarDataClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<Calendar> GetDayNowAsync()
    {
        string responsetext = new StreamReader(HttpWebRequest.Create($"{_configuration["WebAPICalendar"]}")
            .GetResponse()
            .GetResponseStream())
            .ReadToEnd();

        Calendar? calendar =
                JsonSerializer.Deserialize<Calendar>(
                responsetext,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });      
        return calendar;
    }
}

