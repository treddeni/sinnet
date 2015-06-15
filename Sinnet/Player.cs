using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinnet
{
    class Player
    {
        private List<Match> matches = new List<Match>();
        private int wins = 0;
        private int losses = 0;
        private int numMatches = 0;
        private double owp = 0.0;   //opponents winning percentage
        private double oowp = 0.0;  //opponents opponents winning percentage
        private double rpi = 0.0;   //ratings percentage index
        private double sr = 0.0;    //strength rating
        private double elo = 0.0;
        private double matchQuality = 0.0;
        private double dataQuality = 0.0;

        public Player(string name)
        {
            Name = name;
            Rating = 8;
            ELO = 8;
            MatchesCalculated = 0;
        }

        public string Name { get; set; }

        public double Rating { get; set; }
        public int Wins { get { return wins; } }
        public int Losses { get { return losses; } }
        public int NumMatches { get { return numMatches; } }
        public int MatchesCalculated { get; set; }
        public double OWP { get { return owp; } set { owp = value; } }
        public double OOWP { get { return oowp; } set { oowp = value; } }
        public double RPI { get { return rpi; } set { rpi = value; } }
        public double SR { get { return sr; } set { sr = value; } }
        public double ELO { get { return elo; } set { elo = value; } }
        public double MatchQuality { get { return matchQuality; } set { matchQuality = value; } }
        public double DataQuality { get { return dataQuality; } set { dataQuality = value; } }

        public List<Result> Results
        {
            get
            {
                List<Result> results = new List<Result>();
                Result result;

                foreach (Match match in matches)
                {
                    result = new Result();
                    
                    if(match.Winner.Equals(Name))
                    {
                        result.Win = true;
                        result.Opponent = match.Loser;

                        Player opponent = PlayerManager.GetPlayer(match.Loser);
                        result.OpponentELO = opponent.ELO;
                        result.OpponentDQ = opponent.DataQuality;
                    }
                    else
                    {
                        result.Win = false;
                        result.Opponent = match.Winner;

                        Player opponent = PlayerManager.GetPlayer(match.Winner);
                        result.OpponentELO = opponent.ELO;
                        result.OpponentDQ = opponent.DataQuality;
                    }

                    result.Score = match.Score;
                    results.Add(result);
                }

                return results;
            }
        }

        public string Record
        {
            get
            {
                return wins.ToString() + "-" + losses.ToString();
            }
        }

        public double WinningPercentage
        {
            get
            {
                return (double)wins / (double)(wins + losses);
            }
        }

        public string GetOpponent(Match match)
        {
            if (match.Winner.Equals(Name))
            {
                return match.Loser;
            }
            else
            {
                return match.Winner;
            }
        }

        public List<Match> Matches
        {
            get
            {
                return matches;
            }
            set
            {
                matches = new List<Match>();

                foreach (Match match in value)
                {
                    if (match.Winner.Equals(Name))
                    {
                        matches.Add(match);
                        wins++;
                        numMatches++;
                    }
                    else if (match.Loser.Equals(Name))
                    {
                        matches.Add(match);
                        losses++;
                        numMatches++;
                    }
                }

                //calculate match quality
                matchQuality = 0.0;
                
                foreach (Match match in matches)
                {
                    double percentGamesWon = match.GetPercentGamesWon(this.Name);

                    if (percentGamesWon >= .75 || percentGamesWon <= .25)
                    {
                        matchQuality += 2;
                    }
                    else if((percentGamesWon > .65 && percentGamesWon < .75) || (percentGamesWon < .35 && percentGamesWon > .25))
                    {
                        matchQuality += 5;
                    }
                    else if(percentGamesWon <= .65 && percentGamesWon >= .35)
                    {
                        matchQuality += 10;
                    }
                }
            }
        }

        public void Print()
        {
            Console.WriteLine();
            Console.WriteLine(Name + " " + Record + " " + string.Format("{0:N3}", WinningPercentage) + " " + string.Format("{0:N3}", OWP) + " " + string.Format("{0:N3}", OOWP) + " " + string.Format("{0:N3}", RPI));

            foreach (Match match in Matches)
            {
                match.Print();
            }
        }
    }
}
