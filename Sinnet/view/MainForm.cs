using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sinnet.controller;

namespace Sinnet
{
    public partial class MainForm : Form
    {
        private MainController controller;

        public MainForm(MainController controller)
        {
            InitializeComponent();

            this.controller = controller;
            controller.processData();

            playersListBox.Sorted = true;
            playersListBox.DataSource = controller.getPlayers();
            playersListBox.DisplayMember = "Name";

            numPlayersLabel.Text = controller.getNumberOfPlayers().ToString();
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

            resultsListBox.DataSource = controller.getPlayerResults(player);
        }
    }
}
