using ClassLibrary.Models;
using ClassLibrary.Models.Match;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary.BasicSettingsFM;

namespace ClassLibrary.API
{
    public class Get
    {

        public static Task<List<Team>> GetTeams()
        {
            return Task.Run(() =>
            {
                RestClient restClient;
                if (BasicSettingsFM.GetCompetition() == Competition.Female)
                    restClient = new RestClient("https://worldcup.sfg.io/teams/results");
                else
                    restClient = new RestClient("https://world-cup-json-2018.herokuapp.com/teams/results");

                var result = restClient.Execute<Team>(new RestRequest());

                return JsonConvert.DeserializeObject<List<Team>>(result.Content);
            });
        }

        public static Task<List<Match>> GetMatch(string code, Competition competition)
        {
            return Task.Run(() =>
            {
                RestClient restClient;

                if (competition == Competition.Male)
                    restClient = new RestClient($"https://world-cup-json-2018.herokuapp.com/matches/country?fifa_code={code}");
                else
                    restClient = new RestClient($"https://worldcup.sfg.io/matches/country?fifa_code={code}");

                var result = restClient.Execute<Match>(new RestRequest());
                return JsonConvert.DeserializeObject<List<Match>>(result.Content);
            });
        }

    }
}
