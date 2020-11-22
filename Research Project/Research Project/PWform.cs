using System;
using System.Windows.Forms;


namespace Research_Project
{
    public partial class PWform : Form
    {
        public PWform()
        {
            InitializeComponent();
        }

        // CSV file of stats for year 2019.
        string stats2019path = @"C:\Users\Ryank\source\repos\KardasR\Research-Project\Research Project\Research Project\2018-2019teamStats.csv";

        // Let's us use all of our custom methods.
        Methods methods = new Methods();

        /// <summary>
        /// Button that will run the prediction.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPredict_Click(object sender, EventArgs e)
        {
            // TODO: Make program wait until the user has selected two teams.

            // Get the stats for the two teams.
            string teamAStats = methods.GetTeamStats((string)listBoxTeamA.SelectedItem, stats2019path);
            string teamBStats = methods.GetTeamStats((string)listBoxTeamB.SelectedItem, stats2019path);

            // Get the Original Pythagorean Wins for each team.
            double teamAogPW = methods.OrigPythWins(teamAStats);
            double teamBogPW = methods.OrigPythWins(teamBStats);

            // Get the Adjusted Pythagorean Wins for each team.
            double teamAadjPW = methods.AdjPythWins(teamAStats);
            double teamBadjPW = methods.AdjPythWins(teamBStats);

            // Get the Real Winning Percentage for each team.
            double teamArealWinPerc = methods.GetStat(teamAStats, 7);
            double teamBrealWinPerc = methods.GetStat(teamBStats, 7);

            // Get the 

            // Update the UI.
            txtbxTeamAwinPer.Text = teamArealWinPerc.ToString();
            txtbxTeamBwinPer.Text = teamBrealWinPerc.ToString();

            txtbxTeamAadjPW.Text = teamAadjPW.ToString();
            txtbxTeamBadjPW.Text = teamBadjPW.ToString();

            txtbxTeamAogPW.Text = teamAogPW.ToString();
            txtbxTeamBogPW.Text = teamBogPW.ToString();

            // Show the predicted winner of the Original Pythagorean Wins method.
            if (teamAogPW > teamBogPW)
                txtbxOGPWWinner.Text = listBoxTeamA.Text;
            else
                txtbxOGPWWinner.Text = listBoxTeamB.Text;

            // Show the predicted winner of the Adjusted Pythagorean Wins method.
            if (teamAadjPW > teamBadjPW)
                txtbxAPWWinner.Text = listBoxTeamA.Text;
            else
                txtbxAPWWinner.Text = listBoxTeamB.Text;

            // Show the predicted winner of the Real Winning percentage comparison
            if (teamArealWinPerc > teamBrealWinPerc)
                txtbxRealWPWinner.Text = listBoxTeamA.Text;
            else
                txtbxRealWPWinner.Text = listBoxTeamB.Text;
        }
    }
}
