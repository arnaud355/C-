using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class TournamentModel
    {
        public string TournamentName { get; set; }
        public decimal EntryFee { get; set; }

        public List<TeamModel> EnteredTeam { get; set; } = new List<TeamModel>();

        public List<PrizeModel> Prizes { get; } = new List<PrizeModel>();
        public List<List<MatchupModel>> Round { get; } = new List<List<MatchupModel>>();
    }
}
