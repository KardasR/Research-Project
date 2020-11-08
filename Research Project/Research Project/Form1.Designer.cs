namespace Research_Project
{
    partial class Form1
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.textboxWinner = new System.Windows.Forms.TextBox();
            this.textboxWins = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPredict = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxWinPerc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Items.AddRange(new object[] {
            "Anaheim Ducks",
            "Arizona Coyotes",
            "Boston Bruins",
            "Buffalo Sabres",
            "Calgary Flames",
            "Carolina Hurricanes",
            "Chicago Blackhawks",
            "Colorado Avalanche",
            "Columbus Blue Jackets",
            "Dallas Stars",
            "Detroit Red Wings",
            "Edmonton Oilers",
            "Florida Panthers",
            "Los Angeles Kings",
            "Minnesota Wild",
            "Montreal Canadiens",
            "Nashville Predators",
            "New Jersey Devils",
            "New York Islanders",
            "New York Rangers",
            "Ottawa Senators",
            "Philadelphia Flyers",
            "Pittsburgh Penguins",
            "San Jose Sharks",
            "St. Louis Blues",
            "Tampa Bay Lightning",
            "Toronto Maple Leafs",
            "Vancouver Canucks",
            "Vegas Golden Knights",
            "Washington Capitals",
            "Winnipeg Jets"});
            this.listBox1.Location = new System.Drawing.Point(12, 132);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(145, 24);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Items.AddRange(new object[] {
            "Anaheim Ducks",
            "Arizona Coyotes",
            "Boston Bruins",
            "Buffalo Sabres",
            "Calgary Flames",
            "Carolina Hurricanes",
            "Chicago Blackhawks",
            "Colorado Avalanche",
            "Columbus Blue Jackets",
            "Dallas Stars",
            "Detroit Red Wings",
            "Edmonton Oilers",
            "Florida Panthers",
            "Los Angeles Kings",
            "Minnesota Wild",
            "Montreal Canadiens",
            "Nashville Predators",
            "New Jersey Devils",
            "New York Islanders",
            "New York Rangers",
            "Ottawa Senators",
            "Philadelphia Flyers",
            "Pittsburgh Penguins",
            "San Jose Sharks",
            "St. Louis Blues",
            "Tampa Bay Lightning",
            "Toronto Maple Leafs",
            "Vancouver Canucks",
            "Vegas Golden Knights",
            "Washington Capitals",
            "Winnipeg Jets"});
            this.listBox2.Location = new System.Drawing.Point(426, 132);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(145, 24);
            this.listBox2.TabIndex = 1;
            // 
            // textboxWinner
            // 
            this.textboxWinner.Location = new System.Drawing.Point(284, 56);
            this.textboxWinner.Name = "textboxWinner";
            this.textboxWinner.ReadOnly = true;
            this.textboxWinner.Size = new System.Drawing.Size(100, 20);
            this.textboxWinner.TabIndex = 2;
            // 
            // textboxWins
            // 
            this.textboxWins.Location = new System.Drawing.Point(284, 120);
            this.textboxWins.Name = "textboxWins";
            this.textboxWins.ReadOnly = true;
            this.textboxWins.Size = new System.Drawing.Size(100, 20);
            this.textboxWins.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Winner";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Wins";
            // 
            // btnPredict
            // 
            this.btnPredict.Location = new System.Drawing.Point(206, 163);
            this.btnPredict.Name = "btnPredict";
            this.btnPredict.Size = new System.Drawing.Size(178, 67);
            this.btnPredict.TabIndex = 6;
            this.btnPredict.Text = "Predict";
            this.btnPredict.UseVisualStyleBackColor = true;
            this.btnPredict.Click += new System.EventHandler(this.btnPredict_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(53, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Team A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(466, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Team B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label5.Location = new System.Drawing.Point(171, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(255, 31);
            this.label5.TabIndex = 9;
            this.label5.Text = "Predict NHL Games";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(143, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Win Percentage (%)";
            // 
            // textBoxWinPerc
            // 
            this.textBoxWinPerc.Location = new System.Drawing.Point(284, 87);
            this.textBoxWinPerc.Name = "textBoxWinPerc";
            this.textBoxWinPerc.ReadOnly = true;
            this.textBoxWinPerc.Size = new System.Drawing.Size(100, 20);
            this.textBoxWinPerc.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 240);
            this.Controls.Add(this.textBoxWinPerc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPredict);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textboxWins);
            this.Controls.Add(this.textboxWinner);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "NHL Predictor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.TextBox textboxWinner;
        private System.Windows.Forms.TextBox textboxWins;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPredict;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxWinPerc;
    }
}

