using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Research_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // CSV file of stats for year 2019.
        string stats2019path = @"E:\School\Senior Research\Research Project\Research Project\2018-2019teamStats.csv";



        /// <summary>
        /// Finds stats of given team in given file.
        /// </summary>
        /// <param name="teamName">Name of team to retrieve stats for.</param>
        /// <param name="path">Path of the CSV file to look at.</param>
        /// <returns name="currentLine">String of stats for given team.</returns>
        private string GetTeamStats(string teamName, string path)
        {
            // Used to read the CSV file.
            using (StreamReader sr = new StreamReader(path))
            {
                // Skip the first line as it's just a header.
                string currentLine = sr.ReadLine();

                // Look line by line until the EOF.
                while ((currentLine = sr.ReadLine()) != null)
                {
                    // Search for teamA name in current line. If it's there, return the line.
                    if (currentLine.IndexOf(teamName, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        return currentLine;
                    }
                }
                // There should never not be a match for a given team name.
                return "You should never be seeing this. I'm just putting this here to avoid an error.";
            }
        }

        /// <summary>
        /// Retrieve individual stat of a team.
        /// </summary>
        /// <param name="teamStats">Line from CSV file to look through.</param>
        /// <param name="statPos">Position in the CSV line of the stat. (Wins,Losses,etc.)</param>
        /// <returns name="stat">Individual stat that was requested.</returns>
        private int GetStat(string teamStats, int statPos)
        {
            // Split the given string into an array and return the value in the given position.
            string[] stats = teamStats.Split(',');
            int stat = int.Parse(stats[statPos]);
            return stat;
        }

        /// <summary>
        /// <para>The formula for Pythagorean Wins is:
        /// 
        /// PW = (PF^X) / ((PF^X) + (PA^X))
        /// </para>
        /// 
        /// <para>
        /// Where:
        /// PW = Pythagorean Wins | 
        /// PF = Points For (Goals For is used for Ice Hockey) | 
        /// PA = Points Against (Goals Against is used for Ice Hockey) |
        /// X  = Exponents that are changed depending on the sport (Original value is 2)
        /// </para>
        /// </summary>
        /// <param name="teamAname"></param>
        /// <param name="teamBname"></param>
        /// <returns></returns>
        private double OrigPythWins(string teamStats)
        {
            // Goals for is at pos = 8 in string csv
            // Goal Against is at pos = 9 in string csv

            // First do teamA
            int goalsFor = GetStat(teamStats, 8);
            int goalsAgainst = GetStat(teamStats, 9);

            double pythWins = (Math.Pow(goalsFor, 2) / ((Math.Pow(goalsFor, 2)) + (Math.Pow(goalsAgainst, 2))));

            return pythWins;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teamAname"></param>
        /// <param name="teamBname"></param>
        /// <returns></returns>
        private int AdjPythWins(string teamAname, string teamBname)
        {
            // TODO: Add the formula
            return 0;
        }

        /// <summary>
        /// Button that will run the prediction.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPredict_Click(object sender, EventArgs e)
        {
            // TODO: Make program wait until the user has selected two teams.

            // Get the stats for the two teams.
            string teamAStats = GetTeamStats((string)listBoxTeamA.SelectedItem, stats2019path);
            string teamBStats = GetTeamStats((string)listBoxTeamB.SelectedItem, stats2019path);

            // Get the Original Pythagorean Wins for each team.
            double teamAogPW = OrigPythWins(teamAStats);
            double teamBogPW = OrigPythWins(teamBStats);

            // Update the UI.
            txtbxTeamAogPW.Text = teamAogPW.ToString();
            txtbxTeamBogPW.Text = teamBogPW.ToString();
        }
    }
}
