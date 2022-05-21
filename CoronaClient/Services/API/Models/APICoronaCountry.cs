namespace CoronaClient.Services.API.Models
{
    public class APICoronaCountry
    {
        public string? Country { get; set; }
        public int Cases { get; set; }
        public APICoronaCountryInfo? CountryInfo { get; set; }
    }
}