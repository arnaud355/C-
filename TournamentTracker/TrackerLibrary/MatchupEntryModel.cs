using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class MatchupEntryModel
    {
        // Represents one team in the matchup
        public TeamModel TeamCompeting { get; set; }

        // Represents the socre for this particular team
        public double Score { get; set; }

        // Represents the matchup that this team came from as the winner
        public MatchupModel ParentMatchup { get; set; }

        public MatchupEntryModel(double initialScore)
        {

        }
    }
}
