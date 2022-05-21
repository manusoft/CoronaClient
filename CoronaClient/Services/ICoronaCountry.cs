using CoronaClient.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaClient.Services;

public interface ICoronaCountry
{
    Task<IEnumerable<CoronaCountry>> GetTopCases(int amountOfCountries);
}
