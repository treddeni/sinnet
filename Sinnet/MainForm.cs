using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinnet
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //Process matches
            List<Match> matches = Parser.Parse(@"C:\projects\sinnet\data\results-open.csv");

            foreach (Match match in matches)
            {
                PlayerManager.AddPlayer(match.Winner);
                PlayerManager.AddPlayer(match.Loser);
            }

            PlayerManager.AssignMatchesToPlayers(matches);
            PlayerManager.CalculateStats();

            Rater.CalculateELO(matches);

            //PlayerManager.PrintRatingList();

            playersListBox.Sorted = true;
            playersListBox.DataSource = PlayerManager.players;
            playersListBox.DisplayMember = "Name";

            numPlayersLabel.Text = PlayerManager.players.Count.ToString();

            List<string> applicantNames = Parser.ParseApplicants(@"C:\projects\sinnet\data\applicants.csv");
            List<Player> applicants = new List<Player>();

            int totalApplicants = 0;

            foreach(string applicant in applicantNames)
            {
                totalApplicants++;

                Player player = PlayerManager.GetPlayer(applicant);
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

        private void playersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player player = (Player)playersListBox.SelectedItem;

            playerNameLabel.Text = player.Name;
            recordLabel.Text = player.Wins.ToString() + "-" + player.Losses.ToString() + " (" + string.Format("{0:N3}", player.WinningPercentage) + ")";
            rpiLabel.Text = string.Format("{0:N3}", player.RPI);
            srLabel.Text = string.Format("{0:N3}", player.SR);
            eloLabel.Text = string.Format("{0:N3}", player.ELO);
            matchQualityLabel.Text = string.Format("{0:N3}", player.MatchQuality);
            dataQualityLabel.Text = string.Format("{0:N3}", player.DataQuality);

            resultsListBox.DataSource = player.Results;
        }
    }
}
