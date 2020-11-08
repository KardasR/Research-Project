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
            this.listBoxTeamA = new System.Windows.Forms.ListBox();
            this.listBoxTeamB = new System.Windows.Forms.ListBox();
            this.btnPredict = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtbxTeamAogPW = new System.Windows.Forms.TextBox();
            this.txtbxTeamAadjPW = new System.Windows.Forms.TextBox();
            this.txtbxTeamBogPW = new System.Windows.Forms.TextBox();
            this.txtbxTeamBadjPW = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBoxTeamA
            // 
            this.listBoxTeamA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.listBoxTeamA.FormattingEnabled = true;
            this.listBoxTeamA.ItemHeight = 20;
            this.listBoxTeamA.Items.AddRange(new object[] {
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
            this.listBoxTeamA.Location = new System.Drawing.Point(12, 210);
            this.listBoxTeamA.Name = "listBoxTeamA";
            this.listBoxTeamA.Size = new System.Drawing.Size(145, 24);
            this.listBoxTeamA.TabIndex = 0;
            // 
            // listBoxTeamB
            // 
            this.listBoxTeamB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.listBoxTeamB.FormattingEnabled = true;
            this.listBoxTeamB.ItemHeight = 20;
            this.listBoxTeamB.Items.AddRange(new object[] {
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
            this.listBoxTeamB.Location = new System.Drawing.Point(426, 210);
            this.listBoxTeamB.Name = "listBoxTeamB";
            this.listBoxTeamB.Size = new System.Drawing.Size(145, 24);
            this.listBoxTeamB.TabIndex = 1;
            // 
            // btnPredict
            // 
            this.btnPredict.Location = new System.Drawing.Point(177, 194);
            this.btnPredict.Name = "btnPredict";
            this.btnPredict.Size = new System.Drawing.Size(231, 60);
            this.btnPredict.TabIndex = 6;
            this.btnPredict.Text = "Predict";
            this.btnPredict.UseVisualStyleBackColor = true;
            this.btnPredict.Click += new System.EventHandler(this.btnPredict_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(53, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Team A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(466, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Team B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(132, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(343, 39);
            this.label5.TabIndex = 9;
            this.label5.Text = "Predict NHL Games";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(118, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Team A Predictions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(331, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Team B Predictions";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 26);
            this.label6.TabIndex = 12;
            this.label6.Text = "Original \r\nPythagorean Wins";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 26);
            this.label8.TabIndex = 14;
            this.label8.Text = "Adjusted\r\nPythagorean Wins";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(440, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 26);
            this.label7.TabIndex = 16;
            this.label7.Text = "Adjusted\r\nPythagorean Wins";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(440, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 26);
            this.label9.TabIndex = 15;
            this.label9.Text = "Original \r\nPythagorean Wins";
            // 
            // txtbxTeamAogPW
            // 
            this.txtbxTeamAogPW.Location = new System.Drawing.Point(149, 105);
            this.txtbxTeamAogPW.Name = "txtbxTeamAogPW";
            this.txtbxTeamAogPW.ReadOnly = true;
            this.txtbxTeamAogPW.Size = new System.Drawing.Size(100, 20);
            this.txtbxTeamAogPW.TabIndex = 17;
            // 
            // txtbxTeamAadjPW
            // 
            this.txtbxTeamAadjPW.Location = new System.Drawing.Point(149, 143);
            this.txtbxTeamAadjPW.Name = "txtbxTeamAadjPW";
            this.txtbxTeamAadjPW.ReadOnly = true;
            this.txtbxTeamAadjPW.Size = new System.Drawing.Size(100, 20);
            this.txtbxTeamAadjPW.TabIndex = 18;
            // 
            // txtbxTeamBogPW
            // 
            this.txtbxTeamBogPW.Location = new System.Drawing.Point(334, 105);
            this.txtbxTeamBogPW.Name = "txtbxTeamBogPW";
            this.txtbxTeamBogPW.ReadOnly = true;
            this.txtbxTeamBogPW.Size = new System.Drawing.Size(100, 20);
            this.txtbxTeamBogPW.TabIndex = 19;
            // 
            // txtbxTeamBadjPW
            // 
            this.txtbxTeamBadjPW.Location = new System.Drawing.Point(334, 142);
            this.txtbxTeamBadjPW.Name = "txtbxTeamBadjPW";
            this.txtbxTeamBadjPW.ReadOnly = true;
            this.txtbxTeamBadjPW.Size = new System.Drawing.Size(100, 20);
            this.txtbxTeamBadjPW.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 264);
            this.Controls.Add(this.txtbxTeamBadjPW);
            this.Controls.Add(this.txtbxTeamBogPW);
            this.Controls.Add(this.txtbxTeamAadjPW);
            this.Controls.Add(this.txtbxTeamAogPW);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPredict);
            this.Controls.Add(this.listBoxTeamB);
            this.Controls.Add(this.listBoxTeamA);
            this.Name = "Form1";
            this.Text = "NHL Predictor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTeamA;
        private System.Windows.Forms.ListBox listBoxTeamB;
        private System.Windows.Forms.Button btnPredict;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtbxTeamAogPW;
        private System.Windows.Forms.TextBox txtbxTeamAadjPW;
        private System.Windows.Forms.TextBox txtbxTeamBogPW;
        private System.Windows.Forms.TextBox txtbxTeamBadjPW;
    }
}

