using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GenshinVLeague.Controllers
{

    public class CountriesController : ApiController
    {
        LeagueVGenshinEntities myDB = new LeagueVGenshinEntities();

        public IHttpActionResult GetAllCountries()
        {
            var allCountries = from countries in myDB.LeagueCountries
                                  select countries.Country;

            List<string> countriesList = new List<string>();
            foreach (var item in allCountries)
            {
                countriesList.Add(item);
            }
            return Json(countriesList);
        }

        public IHttpActionResult GetAllCountries(string id)
        {
            var countryGameData = from countries in myDB.LeagueCountries
                                  join genshinCountries in myDB.GenshinCountries on countries.Country equals genshinCountries.Country
                                  where countries.Country == id
                                  select new { countries.Country, countries.LeaguePopularity, genshinCountries.GenshinPopularity };

            List<CountryList> countriesGameList = new List<CountryList>();
            foreach (var item in countryGameData)
            {
                countriesGameList.Add(new CountryList(item.Country, item.LeaguePopularity, item.GenshinPopularity));
            }
            return Json(countriesGameList);
        }
    }

    class CountryList
    {
        public CountryList(string pCountry, string pLeague, string pGenshin)
        {
            Country = pCountry;
            LeaguePopularity = pLeague;
            GenshinPopularity = pGenshin;
        }
        public string Country { get; set; }
        public string LeaguePopularity { get; set; }
        public string GenshinPopularity { get; set; }
    }
}
