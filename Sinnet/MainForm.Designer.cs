namespace Sinnet
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playersListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numPlayersLabel = new System.Windows.Forms.Label();
            this.resultsListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.playerNameLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.recordLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rpiLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.srLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.eloLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.matchQualityLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataQualityLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // playersListBox
            // 
            this.playersListBox.FormattingEnabled = true;
            this.playersListBox.ItemHeight = 20;
            this.playersListBox.Location = new System.Drawing.Point(18, 38);
            this.playersListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.playersListBox.Name = "playersListBox";
            this.playersListBox.Size = new System.Drawing.Size(304, 564);
            this.playersListBox.TabIndex = 1;
            this.playersListBox.SelectedIndexChanged += new System.EventHandler(this.playersListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Players:";
            // 
            // numPlayersLabel
            // 
            this.numPlayersLabel.AutoSize = true;
            this.numPlayersLabel.Location = new System.Drawing.Point(94, 14);
            this.numPlayersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numPlayersLabel.Name = "numPlayersLabel";
            this.numPlayersLabel.Size = new System.Drawing.Size(18, 20);
            this.numPlayersLabel.TabIndex = 3;
            this.numPlayersLabel.Text = "0";
            // 
            // resultsListBox
            // 
            this.resultsListBox.FormattingEnabled = true;
            this.resultsListBox.ItemHeight = 20;
            this.resultsListBox.Location = new System.Drawing.Point(664, 38);
            this.resultsListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.resultsListBox.Name = "resultsListBox";
            this.resultsListBox.Size = new System.Drawing.Size(727, 564);
            this.resultsListBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name:";
            // 
            // playerNameLabel
            // 
            this.playerNameLabel.AutoSize = true;
            this.playerNameLabel.Location = new System.Drawing.Point(456, 38);
            this.playerNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playerNameLabel.Name = "playerNameLabel";
            this.playerNameLabel.Size = new System.Drawing.Size(18, 20);
            this.playerNameLabel.TabIndex = 6;
            this.playerNameLabel.Text = "_";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Record:";
            // 
            // recordLabel
            // 
            this.recordLabel.AutoSize = true;
            this.recordLabel.Location = new System.Drawing.Point(456, 58);
            this.recordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.recordLabel.Name = "recordLabel";
            this.recordLabel.Size = new System.Drawing.Size(18, 20);
            this.recordLabel.TabIndex = 6;
            this.recordLabel.Text = "_";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(660, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Results:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(405, 78);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "RPI:";
            // 
            // rpiLabel
            // 
            this.rpiLabel.AutoSize = true;
            this.rpiLabel.Location = new System.Drawing.Point(456, 78);
            this.rpiLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rpiLabel.Name = "rpiLabel";
            this.rpiLabel.Size = new System.Drawing.Size(18, 20);
            this.rpiLabel.TabIndex = 6;
            this.rpiLabel.Text = "_";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(410, 98);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "SR:";
            // 
            // srLabel
            // 
            this.srLabel.AutoSize = true;
            this.srLabel.Location = new System.Drawing.Point(456, 98);
            this.srLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.srLabel.Name = "srLabel";
            this.srLabel.Size = new System.Drawing.Size(18, 20);
            this.srLabel.TabIndex = 6;
            this.srLabel.Text = "_";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(400, 118);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "ELO:";
            // 
            // eloLabel
            // 
            this.eloLabel.AutoSize = true;
            this.eloLabel.Location = new System.Drawing.Point(456, 118);
            this.eloLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.eloLabel.Name = "eloLabel";
            this.eloLabel.Size = new System.Drawing.Size(18, 20);
            this.eloLabel.TabIndex = 6;
            this.eloLabel.Text = "_";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(334, 172);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Match Quality:";
            // 
            // matchQualityLabel
            // 
            this.matchQualityLabel.AutoSize = true;
            this.matchQualityLabel.Location = new System.Drawing.Point(456, 172);
            this.matchQualityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.matchQualityLabel.Name = "matchQualityLabel";
            this.matchQualityLabel.Size = new System.Drawing.Size(18, 20);
            this.matchQualityLabel.TabIndex = 6;
            this.matchQualityLabel.Text = "_";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(345, 192);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "Data Quality:";
            // 
            // dataQualityLabel
            // 
            this.dataQualityLabel.AutoSize = true;
            this.dataQualityLabel.Location = new System.Drawing.Point(456, 192);
            this.dataQualityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dataQualityLabel.Name = "dataQualityLabel";
            this.dataQualityLabel.Size = new System.Drawing.Size(18, 20);
            this.dataQualityLabel.TabIndex = 6;
            this.dataQualityLabel.Text = "_";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1412, 626);
            this.Controls.Add(this.dataQualityLabel);
            this.Controls.Add(this.matchQualityLabel);
            this.Controls.Add(this.eloLabel);
            this.Controls.Add(this.srLabel);
            this.Controls.Add(this.rpiLabel);
            this.Controls.Add(this.recordLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.playerNameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resultsListBox);
            this.Controls.Add(this.numPlayersLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playersListBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Sinnet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox playersListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label numPlayersLabel;
        private System.Windows.Forms.ListBox resultsListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label playerNameLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label recordLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label rpiLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label srLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label eloLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label matchQualityLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label dataQualityLabel;
    }
}

