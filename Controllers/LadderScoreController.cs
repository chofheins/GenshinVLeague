using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GenshinVLeague.Controllers
{
    public class LadderScoreController : ApiController
    {
        LeagueVGenshinEntities myDB = new LeagueVGenshinEntities();

        public IHttpActionResult GetByLadderScore(decimal id)
        {
            var ladderScores = from ladderLeague in myDB.LeagueCountries
                               join ladderGenshin in myDB.GenshinCountries on ladderLeague.Country equals ladderGenshin.Country
                               where Decimal.Floor(ladderLeague.LadderScore).Equals(id)
                               select new { ladderLeague.Country, ladderLeague.LeaguePopularity, ladderGenshin.GenshinPopularity, ladderLeague.LadderScore };

            List<LadderList> ladderScoreList = new List<LadderList>();
            foreach (var item in ladderScores)
            {
                ladderScoreList.Add(new LadderList(item.Country, item.LeaguePopularity, item.GenshinPopularity, item.LadderScore));
            }
            return Json(ladderScoreList);
        }
    }

    class LadderList
    {
        public LadderList(string pCountry, string pLeague, string pGenshin, decimal pLadderScore)
        {
            Country = pCountry;
            LeaguePopularity = pLeague;
            GenshinPopularity = pGenshin;
            LadderScore = pLadderScore;
        }
        public string Country { get; set; }
        public string LeaguePopularity { get; set; }
        public string GenshinPopularity { get; set; }
        public decimal LadderScore { get; set; }
    }
}
