using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinnet
{
    public class Match
    {
        public Match(string winner, string loser, string[] scores)
        {
            Winner = winner;
            Loser  = loser;

            if (scores.Length >= 2)
            {
                WinnerFirstSetScore = int.Parse(RemoveTiebreakScore(scores[0].Trim()));
                LoserFirstSetScore  = int.Parse(RemoveTiebreakScore(scores[1].Trim()));
            }

            if (scores.Length >= 4)
            {
                WinnerSecondSetScore = int.Parse(RemoveTiebreakScore(scores[2].Trim()));
                LoserSecondSetScore  = int.Parse(RemoveTiebreakScore(scores[3].Trim()));
            }

            if (scores.Length >= 6)
            {
                WinnerThirdSetScore = int.Parse(RemoveTiebreakScore(scores[4].Trim()));
                LoserThirdSetScore  = int.Parse(RemoveTiebreakScore(scores[5].Trim()));
            }

            if (WinnerThirdSetScore > 7)
            {
                WinnerThirdSetScore = 1;
                LoserThirdSetScore = 0;
            }
        }

        public Match(string[] values)
        {
            Winner                  = values[0];
            Loser                   = values[1];
            WinnerFirstSetScore     = int.Parse(values[2]);
            LoserFirstSetScore      = int.Parse(values[3]);
            WinnerSecondSetScore    = int.Parse(values[4]);
            LoserSecondSetScore     = int.Parse(values[5]);
            WinnerThirdSetScore     = int.Parse(values[6]);
            LoserThirdSetScore      = int.Parse(values[7]);
        }

        public string Winner { get; set; }
        public string Loser { get; set; }
        public int WinnerFirstSetScore { get; set; }
        public int LoserFirstSetScore { get; set; }
        public int WinnerSecondSetScore { get; set; }
        public int LoserSecondSetScore { get; set; }
        public int WinnerThirdSetScore { get; set; }
        public int LoserThirdSetScore { get; set; }

        private string RemoveTiebreakScore(string score)
        {
            string simplifiedScore;

            if(score.Contains('('))
            {
                int index = score.IndexOf('(');
                simplifiedScore = score.Remove(index);
            }
            else
            {
                simplifiedScore = score;
            }

            return simplifiedScore;
        }

        private bool ThirdSetPlayed()
        {
            return WinnerThirdSetScore != 0;
        }

        private bool SecondSetPlayed()
        {
            if (WinnerSecondSetScore == 0 && LoserSecondSetScore == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public double GetPercentGamesWon(string playerName)
        {
            double totalGames = WinnerFirstSetScore + WinnerSecondSetScore + WinnerThirdSetScore + LoserFirstSetScore + LoserSecondSetScore + LoserThirdSetScore;

            if (Winner.Equals(playerName))
            {
                return (double)(WinnerFirstSetScore + WinnerSecondSetScore + WinnerThirdSetScore) / totalGames;
            }
            else
            {
                return (double)(LoserFirstSetScore + LoserSecondSetScore + LoserThirdSetScore) / totalGames;
            }
        }

        public string Score
        {
            get
            {
                string score = WinnerFirstSetScore + "-" + LoserFirstSetScore;

                if (SecondSetPlayed())
                {
                    score += ", " + WinnerSecondSetScore + "-" + LoserSecondSetScore;
                }

                if (ThirdSetPlayed())
                {
                    score += ", " + WinnerThirdSetScore + "-" + LoserThirdSetScore;
                }

                return score;
            }
        }

        public double MatchQuality
        {
            get
            {
                double percentGamesWon = GetPercentGamesWon(Winner);

                if ((percentGamesWon > .65 && percentGamesWon < .75) || (percentGamesWon < .35 && percentGamesWon > .25))
                {
                    return 5;
                }
                else if (percentGamesWon <= .65 && percentGamesWon >= .35)
                {
                    return 10;
                }
                else
                {
                    return 2;
                }
            }
        }

        public void Print()
        {

            if (ThirdSetPlayed())
            {
                Console.WriteLine(Winner + " d. " + Loser + " " + WinnerFirstSetScore + "-" + LoserFirstSetScore + ", " + WinnerSecondSetScore + "-" + LoserSecondSetScore + ", " + WinnerThirdSetScore + "-" + LoserThirdSetScore);
            }
            else
            {
                Console.WriteLine(Winner + " d. " + Loser + " " + WinnerFirstSetScore + "-" + LoserFirstSetScore + ", " + WinnerSecondSetScore + "-" + LoserSecondSetScore);
            }
        }
    }
}
