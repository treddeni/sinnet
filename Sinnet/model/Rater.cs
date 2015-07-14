using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinnet
{
    class Rater
    {
        public static void CalculateELO(List<Match> matches, PlayerManager playerManager)
        {
            //calculate rating
            Player winner;
            Player loser;
            double rd;              //rating difference
            double s;               //actual score
            double ew;              //winner's expectation
            double kw;              //winner's adjustment factor
            double kl;              //loser's adjustment factor

            CalculateDataQuality(playerManager);

            //seed with RPI
            foreach (Player player in playerManager.players)
            {
                //player.ELO = 3.0 + 8.0 * player.SR;
                player.ELO = 4.0 + 8.0 * player.RPI;
            }

            foreach (Match match in matches)
            {
                winner = playerManager.GetPlayer(match.Winner);
                loser = playerManager.GetPlayer(match.Loser);

                rd = loser.ELO - winner.ELO;

                s = match.GetPercentGamesWon(winner.Name);
                ew = 1 / (1 + Math.Pow(10.0, (rd / 1.5)));
                kw = Math.Max(Math.Log10(loser.DataQuality), 0.2) / Math.Max(Math.Log10(winner.DataQuality), 0.2);
                kl = Math.Max(Math.Log10(winner.DataQuality), 0.2) / Math.Max(Math.Log10(loser.DataQuality), 0.2);

                winner.ELO = winner.ELO + kw * (s - ew);
                loser.ELO = loser.ELO + kl * (ew - s);

                winner.MatchesCalculated++;
                loser.MatchesCalculated++;
            }
        }

        private static void CalculateDataQuality(PlayerManager playerManager)
        {
            Player opponent;

            foreach (Player player in playerManager.players)
            {
                foreach (Match match in player.Matches)
                {
                    opponent = playerManager.GetPlayer(player.GetOpponent(match));

                    player.DataQuality += Math.Log10(opponent.MatchQuality);
                }
            }
        }
    }
}
