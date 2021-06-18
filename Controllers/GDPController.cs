using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GenshinVLeague.Controllers
{
    public class GDPController : ApiController
    {
        LeagueVGenshinEntities myDB = new LeagueVGenshinEntities();

        public IHttpActionResult GetGDP()
        {
            var gdps = from leagueGDP in myDB.LeagueCountries
                       join genshinGDP in myDB.GenshinCountries on leagueGDP.Country equals genshinGDP.Country
                       select new { leagueGDP.Country, leagueGDP.LeaguePopularity, genshinGDP.GenshinPopularity, leagueGDP.GDP };

            List<GDPList> gdpList = new List<GDPList>();
            foreach (var item in gdps)
            {
                gdpList.Add(new GDPList(item.Country, item.LeaguePopularity, item.GenshinPopularity, item.GDP));
            }
            return Json(gdpList);
        }
    }

    class GDPList
    {
        public GDPList(string pCountry, string pLeague, string pGenshin, decimal pGDP)
        {
            Country = pCountry;
            LeaguePopularity = pLeague;
            GenshinPopularity = pGenshin;
            GDP = pGDP;
        }
        public string Country { get; set; }
        public string LeaguePopularity { get; set; }
        public string GenshinPopularity { get; set; }
        public decimal GDP { get; set; }
    }
}
