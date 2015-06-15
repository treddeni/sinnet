using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinnet
{
    class Rater
    {
        public static void CalculateELO(List<Match> matches)
        {
            //calculate rating
            Player winner;
            Player loser;
            double rd;              //rating difference
            double s;               //actual score
            double ew;              //winner's expectation
            double kw;              //winner's adjustment factor
            double kl;              //loser's adjustment factor

            int right = 0;
            int wrong = 0;
            int count = 0;

            CalculateDataQuality();

            //seed with RPI
            foreach (Player player in PlayerManager.players)
            {
                //player.ELO = 3.0 + 8.0 * player.SR;
                player.ELO = 4.0 + 8.0 * player.RPI;
            }

            foreach (Match match in matches)
            {
                count++;
                winner = PlayerManager.GetPlayer(match.Winner);
                loser = PlayerManager.GetPlayer(match.Loser);

                rd = loser.ELO - winner.ELO;

                if (count > 500 && winner.MatchesCalculated > 4 && loser.MatchesCalculated > 4 && Math.Abs(rd) > 0.4 && Math.Abs(rd) < 0.6)
                {
                    if (rd > 0.0)
                    {
                        wrong++;
                    }
                    else
                    {
                        right++;
                    }
                }

                //if (Math.Abs(rd) > 4.0)
                //{
                //    continue;
                //}

                s = match.GetPercentGamesWon(winner.Name);
                ew = 1 / (1 + Math.Pow(10.0, (rd / 1.5)));
                kw = Math.Max(Math.Log10(loser.DataQuality), 0.2) / Math.Max(Math.Log10(winner.DataQuality), 0.2);
                kl = Math.Max(Math.Log10(winner.DataQuality), 0.2) / Math.Max(Math.Log10(loser.DataQuality), 0.2);

                winner.ELO = winner.ELO + kw * (s - ew);
                loser.ELO = loser.ELO + kl * (ew - s);

                winner.MatchesCalculated++;
                loser.MatchesCalculated++;
            }

            double percentPredicted = (double)right / ((double)right + (double)wrong);
            Console.WriteLine("\nPercent Predicted Correctly = " + string.Format("{0:N2}", percentPredicted));

            /*foreach (Player player in PlayerManager.players)
            {
                player.MatchesCalculated = 0;
            }

            foreach (Match match in matches)
            {
                winner = PlayerManager.GetPlayer(match.Winner);
                loser = PlayerManager.GetPlayer(match.Loser);

                rd = loser.ELO - winner.ELO;

                s = match.GetPercentGamesWon(winner.Name);
                ew = 1 / (1 + Math.Pow(10.0, (rd / 1.5)));
                kw = Math.Max(Math.Log10(loser.DataQuality), 0.2) / Math.Max(Math.Log10(winner.DataQuality), 0.2);
                kl = Math.Max(Math.Log10(winner.DataQuality), 0.2) / Math.Max(Math.Log10(loser.DataQuality), 0.2);

                winner.ELO = winner.ELO + kw * (s - ew);
                loser.ELO = loser.ELO + kl * (ew - s);

                winner.MatchesCalculated++;
                loser.MatchesCalculated++;
            }*/
        }

        private static void CalculateDataQuality()
        {
            Player opponent;

            foreach (Player player in PlayerManager.players)
            {
                foreach (Match match in player.Matches)
                {
                    opponent = PlayerManager.GetPlayer(player.GetOpponent(match));

                    player.DataQuality += Math.Log10(opponent.MatchQuality);
                }
            }
        }
    }
}
