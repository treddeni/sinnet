using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinnet
{
    public class PlayerManager
    {
        public List<Player> players;

        public PlayerManager()
        {
            players = new List<Player>();
        }

        public void CalculateStats()
        {
            //calculate OWP
            foreach (Player player in players)
            {
                double sum = 0.0;
                Player opponent;

                foreach (Match match in player.Matches)
                {
                    opponent = GetPlayer(player.GetOpponent(match));
                    sum += opponent.WinningPercentage;
                }

                player.OWP = sum / (double)player.Matches.Count;
            }

            //calculate OOWP
            foreach (Player player in players)
            {
                double sum = 0.0;
                Player opponent;

                foreach (Match match in player.Matches)
                {
                    opponent = GetPlayer(player.GetOpponent(match));
                    sum += opponent.OWP;
                }

                player.OOWP = sum / (double)player.Matches.Count;
            }

            //calculate RPI
            foreach (Player player in players)
            {
                player.RPI = 0.25 * player.WinningPercentage + 0.5 * player.OWP + 0.25 * player.OOWP;
            }

            //calculate SR
            foreach (Player player in players)
            {
                double sum = 0.0;
                Player opponent;

                foreach (Match match in player.Matches)
                {
                    opponent = GetPlayer(player.GetOpponent(match));
                    sum += opponent.RPI * match.GetPercentGamesWon(player.Name);
                }

                player.SR = sum / (double)player.Matches.Count;
            }
        }

        public List<Result> GetPlayerResults(Player player)
        {
            List<Result> results = new List<Result>();
            Result result;

            foreach (Match match in player.Matches)
            {
                result = new Result();
                    
                if(match.Winner.Equals(player.Name))
                {
                    result.Win = true;
                    result.Opponent = match.Loser;

                    Player opponent = GetPlayer(match.Loser);
                    result.OpponentELO = opponent.ELO;
                    result.OpponentDQ = opponent.DataQuality;
                }
                else
                {
                    result.Win = false;
                    result.Opponent = match.Winner;

                    Player opponent = GetPlayer(match.Winner);
                    result.OpponentELO = opponent.ELO;
                    result.OpponentDQ = opponent.DataQuality;
                }

                result.Score = match.Score;
                results.Add(result);
            }

            return results;
        }
 
        public void AddPlayer(string name)
        {
            bool alreadyExists = false;

            foreach (Player player in players)
            {
                if (player.Name.Equals(name))
                {
                    alreadyExists = true;
                }
            }

            if (!alreadyExists)
            {
                players.Add(new Player(name));
            }
        }

        public void AssignMatchesToPlayers(List<Match> matches)
        {
            foreach (Player player in players)
            {
                player.Matches = matches;
            }
        }

        public Player GetPlayer(string name)
        {
            foreach (Player player in players)
            {
                if (player.Name.Equals(name))
                {
                    return player;
                }
            }

            return null;
        }

        public void PrintPlayerList()
        {
            Console.WriteLine();

            foreach(Player player in players)
            {
                Console.WriteLine(player.Name);
            }
        }

        public void PrintPlayers(int numMatches)
        {
            Console.WriteLine();

            foreach (Player player in players)
            {
                if (player.NumMatches > numMatches)
                {
                    player.Print();
                }
            }
        }

        public void PrintRPIList()
        {
            Console.WriteLine();

            List<Player> RPIList = players.OrderByDescending(p => p.RPI).ToList();

            foreach (Player player in RPIList)
            {
                Console.WriteLine(string.Format("{0:N3}", player.RPI) + "    " + player.Name);
            }
        }

        public void PrintSRList()
        {
            Console.WriteLine();

            List<Player> SRList = players.OrderByDescending(p => p.SR).ToList();

            foreach (Player player in SRList)
            {
                Console.WriteLine(string.Format("{0:N3}", player.SR) + "    " + player.Name);
            }
        }

        public string PrintRatingList()
        {
            string ratingsList = "";

            List<Player> RatingList = players.OrderByDescending(p => p.ELO).ToList();

            int i = 1;
            foreach (Player player in RatingList)
            {
                if (player.NumMatches > 0)
                {
                    ratingsList += string.Format("{0:N3}", player.ELO) + "    " + player.Name + "\n";
                    Console.WriteLine(string.Format("{0:N3}", player.ELO) + "    " + i + "  " + player.Name);
                    i++;
                }
            }

            return ratingsList;
        }
    }
}
