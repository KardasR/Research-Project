using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;


namespace Research_Project
{
    public partial class PWform : Form
    {
        public PWform()
        {
            InitializeComponent();
        }

        // Paths for different seasons.
        string season2020 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"2019-2020teamStats.csv");
        string season2019 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"2018-2019teamStats.csv");
        string season2018 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"2017-2018teamStats.csv");
        string season2017 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"2016-2017teamStats.csv");

        // Default season to predict.
        string selectedSeason = "2019-2020";
        // Set the CSV file path to the default season.
        string statsPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"2019-2020teamStats.csv");

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

            if (selectedSeason == "2019-2020")
                statsPath = season2020;
            else if (selectedSeason == "2018-2019")
                statsPath = season2019;
            else if (selectedSeason == "2017-2018")
                statsPath = season2018;
            else if (selectedSeason == "2016-2017")
                statsPath = season2017;

            // Get the stats for the two teams.
            string teamAStats = methods.GetTeamStats((string)listBoxTeamA.SelectedItem, statsPath);
            string teamBStats = methods.GetTeamStats((string)listBoxTeamB.SelectedItem, statsPath);

            // Get the Original Pythagorean Wins for each team.
            double teamAogPW = methods.OrigPythWins(teamAStats);
            double teamBogPW = methods.OrigPythWins(teamBStats);

            // Get the Adjusted Pythagorean Wins for each team.
            double teamAadjPW = methods.AdjPythWins(teamAStats);
            double teamBadjPW = methods.AdjPythWins(teamBStats);

            // Get the Real Winning Percentage for each team.
            double teamArealWinPerc = methods.GetStat(teamAStats, 7);
            double teamBrealWinPerc = methods.GetStat(teamBStats, 7);

            // Get the Ratings Percentage Index for each team.
            double teamArpi = methods.RatingsPercentageIndex(teamAStats, statsPath);
            double teamBrpi = methods.RatingsPercentageIndex(teamBStats, statsPath);

            // Get the Special Teams Percentage for each team.
            double teamASTPer = methods.GetSTPer(teamAStats);
            double teamBSTPer = methods.GetSTPer(teamBStats);

            // Get the Even Strength Ability for each team.
            double teamAEvnAbi = methods.EvenAbil(teamAStats);
            double teamBEvnAbi = methods.EvenAbil(teamBStats);

            double teamASDM = methods.SDM(teamAStats, season2017, season2018, season2019);
            double teamBSDM = methods.SDM(teamBStats, season2017, season2018, season2019);

            // Update the UI.
            txtbxTeamArpi.Text = teamArpi.ToString();
            txtbxTeamBrpi.Text = teamBrpi.ToString();

            txtbxTeamAwinPer.Text = teamArealWinPerc.ToString();
            txtbxTeamBwinPer.Text = teamBrealWinPerc.ToString();

            txtbxTeamAadjPW.Text = teamAadjPW.ToString();
            txtbxTeamBadjPW.Text = teamBadjPW.ToString();

            txtbxTeamAogPW.Text = teamAogPW.ToString();
            txtbxTeamBogPW.Text = teamBogPW.ToString();

            txtbxTeamArpi.Text = teamArpi.ToString();
            txtbxTeamBrpi.Text = teamBrpi.ToString();

            txtbxTeamASTPer.Text = teamASTPer.ToString();
            txtbxTeamBSTPer.Text = teamBSTPer.ToString();

            txtbxTeamAESA.Text = teamAEvnAbi.ToString();
            txtbxTeamBESA.Text = teamBEvnAbi.ToString();

            txtbxTeamASDM.Text = teamASDM.ToString();
            txtbxTeamBSDM.Text = teamBSDM.ToString();

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

            // Show the predicted winner of the Ratings Percentage Index
            if (teamArpi > teamBrpi)
                txtbxRPIWinner.Text = listBoxTeamA.Text;
            else
                txtbxRPIWinner.Text = listBoxTeamB.Text;

            // Show the predicted winner of the Special Teams Indicator (Not an actual prediction method but interesting to look at.)
            if (teamASTPer > teamBSTPer)
                txtbxSTPerWinner.Text = listBoxTeamA.Text;
            else
                txtbxSTPerWinner.Text = listBoxTeamB.Text;

            // Show the predicted winner of the Even Strength Ability (Not an actual prediction method but interesting to look at.)
            if (teamAEvnAbi > teamBEvnAbi)
                txtbxESAWinner.Text = listBoxTeamA.Text;
            else
                txtbxESAWinner.Text = listBoxTeamB.Text;

            // Show the predicted winner of the SDM prediction method
            if (teamASDM > teamBSDM)
                txtbxSDMWinner.Text = listBoxTeamA.Text;
            else
                txtbxSDMWinner.Text = listBoxTeamB.Text;
        }

        private void cbSelSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSeason = cbSelSeason.SelectedItem.ToString();
        }
    }
}
