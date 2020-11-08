using System;
using System.IO;

namespace Research_Project
{
    public class Methods
    {
        /// <summary>
        /// Finds stats of given team in given file.
        /// </summary>
        /// <param name="teamName">Name of team to retrieve stats for.</param>
        /// <param name="path">Path of the CSV file to look at.</param>
        /// <returns name="currentLine">String of stats for given team.</returns>
        public string GetTeamStats(string teamName, string path)
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
                // There should never not be a match for a given team name. But if there is the program will return this to avoid an error.
                return "Hartford Whalers,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            }
        }

        /// <summary>
        /// Retrieve individual stat of a team.
        /// </summary>
        /// <param name="teamStats">Line from CSV file to look through.</param>
        /// <param name="statPos">Position in the CSV line of the stat. (Wins,Losses,etc.)</param>
        /// <returns name="stat">Individual stat that was requested.</returns>
        public double GetStat(string teamStats, int statPos)
        {
            // Split the given string into an array and return the value in the given position.
            string[] stats = teamStats.Split(',');
            double stat = double.Parse(stats[statPos]);
            return stat;
        }

        /// <summary>
        /// <para>
        /// 
        /// This function will use the original Pythagorean Wins formula to get the given teams predicted win percentage.
        /// 
        /// </para>
        /// <para>
        /// 
        /// The formula for Pythagorean Wins is:
        /// 
        /// PW = (PF^X) / ((PF^X) + (PA^X))
        /// </para>
        /// 
        /// <para>
        /// 
        /// Where:
        /// PW = Pythagorean Wins | 
        /// PF = Points For (Goals For is used for Ice Hockey) | 
        /// PA = Points Against (Goals Against is used for Ice Hockey) |
        /// X  = Exponents that are changed depending on the sport (Original value is 2)
        /// 
        /// </para>
        /// </summary>
        /// <param name="teamStats">Line from CSV file to look through.</param>
        /// <returns name="pythWins">Return the win percentage of the given team.</returns>
        public double OrigPythWins(string teamStats)
        {
            // Goals for is at pos = 8 in string csv
            // Goal Against is at pos = 9 in string csv

            // First do teamA
            int goalsFor = (int)GetStat(teamStats, 8);
            int goalsAgainst = (int)GetStat(teamStats, 9);

            double pythWins = (Math.Pow(goalsFor, 2) / ((Math.Pow(goalsFor, 2)) + (Math.Pow(goalsAgainst, 2))));

            return pythWins;
        }

        /// <summary>
        /// <para>
        /// 
        /// This function will use the original Pythagorean Wins formula to get the given teams predicted win percentage.
        /// 
        /// </para>
        /// <para>
        /// 
        /// The formula for Pythagorean Wins is:
        /// 
        /// PW = (PF^X) / ((PF^X) + (PA^X))
        /// </para>
        /// 
        /// <para>
        /// 
        /// Where:
        /// PW = Pythagorean Wins | 
        /// PF = Points For (Goals For is used for Ice Hockey) | 
        /// PA = Points Against (Goals Against is used for Ice Hockey) |
        /// X  = Exponents that are changed depending on the sport (Ice Hockey is, )
        /// 
        /// </para>
        /// </summary>
        /// <param name="teamStats">Line from CSV file to look through.</param>
        /// <returns name="pythWins">Return the win percentage of the given team.</returns>
        public double AdjPythWins(string teamStats)
        {
            // TODO: Add the formula
            double pythWins = 0;
            return pythWins;
        }
    }
}
