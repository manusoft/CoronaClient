using CoronaClient.Models;
using CoronaClient.Services.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoronaClient.Services.API
{
    public class APICoronaCountryService : ICoronaCountry
    {
        public async Task<IEnumerable<CoronaCountry>> GetTopCases(int amountOfCountries)
        {
            using (HttpClient client = new HttpClient())
            {
                string requestUri = "https://corona.lmao.ninja/v3/covid-19/countries?sort=cases";

                HttpResponseMessage apiResponse = await client.GetAsync(requestUri);

                string jasonResponse = await apiResponse.Content.ReadAsStringAsync();

                List<APICoronaCountry>? apiCountries = JsonSerializer.Deserialize<List<APICoronaCountry>>(jasonResponse, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

                return apiCountries.Take(amountOfCountries).Select(apiCountry => new CoronaCountry()
                {
                    CountryName = apiCountry.Country,
                    CaseCount = apiCountry.Cases,
                    FlagUri = apiCountry.CountryInfo.Flag
                });
            }
        }
    }
}
