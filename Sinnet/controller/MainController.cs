using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinnet.controller
{
    public class MainController
    {
        private String dataFilePath;
        private PlayerManager playerManager;

        public MainController(String dataFilePath)
        {
            this.dataFilePath = dataFilePath;
            playerManager = new PlayerManager();
        }

        public void processData()
        {
            List<Match> matches = Parser.Parse(dataFilePath);

            foreach (Match match in matches)
            {
                playerManager.AddPlayer(match.Winner);
                playerManager.AddPlayer(match.Loser);
            }

            playerManager.AssignMatchesToPlayers(matches);
            playerManager.CalculateStats();

            Rater.CalculateELO(matches, playerManager);
        }

        public List<Result> getPlayerResults(Player player)
        {
            return playerManager.GetPlayerResults(player);
        }

        public List<Player> getPlayers()
        {
            return playerManager.players;
        }

        public int getNumberOfPlayers()
        {
            return playerManager.players.Count;
        }

        public void processApplicants()
        {
            List<string> applicantNames = Parser.ParseApplicants(@"C:\projects\sinnet\data\applicants.csv");
            List<Player> applicants = new List<Player>();

            int totalApplicants = 0;

            foreach(string applicant in applicantNames)
            {
                totalApplicants++;

                Player player = playerManager.GetPlayer(applicant);
                if (player != null)
                {
                    applicants.Add(player);
                }
                else
                {
                    Console.WriteLine(applicant);
                }
            }


            double eloSum = 0.0;
            int numApplicants = 0;
            double eloAvg = 0.0;

            foreach (Player applicant in applicants.OrderByDescending(p => p.ELO).ToList())
            {
                Console.WriteLine(string.Format("{0:N1}", applicant.ELO) + "\t[" + string.Format("{0:N0}", applicant.DataQuality) + "] \t" + applicant.Name);

                if (applicant.NumMatches > 0)
                {
                    eloSum += applicant.ELO;
                    numApplicants++;
                }
            }

            Console.WriteLine("\nNumber of Applicants: " + totalApplicants);
            eloAvg = eloSum / (double)numApplicants;
            Console.WriteLine("\nELO Average: " + string.Format("{0:N2}", eloAvg));
        }
    }
}
