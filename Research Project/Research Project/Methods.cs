using System;
using System.Collections.Generic;
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
        /// This will get all the stats of every team in a file.
        ///
        /// </para>
        /// </summary>
        /// <param name="path">Path of the CSV file to look at.</param>
        /// <returns name="allStats">List of all the stats taken from the given CSV file.</returns>
        public List<string> GetAllStats(string path)
        {
            List<string> allStats = new List<string>();
            // Used to read the CSV file.
            using (StreamReader sr = new StreamReader(path))
            {
                // Skip the first line as it's just a header.
                string currentLine = sr.ReadLine();

                // Look line by line until the EOF.
                while ((currentLine = sr.ReadLine()) != null)
                {
                    allStats.Add(currentLine);
                }
            }
            return allStats;
        }

        /// <summary>
        /// <para>
        ///
        /// This function will find the optimal X value for the adjusted Pythagorean Win method.
        /// 
        /// </para>
        ///<para>
        ///
        /// The formula for finding the Percent Difference is:
        /// 
        /// PD = ((n2 - n1) / n2) * 100
        ///
        /// </para>
        /// <para>
        ///
        /// Where:
        /// PD = Percent Difference | 
        /// n1 = The smaller number to be compared | 
        /// n2 = The larger number to be compared | 
        /// 
        /// </para>
        /// </summary>
        /// <param name="teamStats"></param>
        /// <returns name="xValue"></returns>
        public double GetXValue(string teamStats)
        {
            List<double> potXVals = new List<double>();

            double realWinPer = GetStat(teamStats, 7);

            for (double i = 0.01; i < 5; i += 0.01)
            {
                double pythWins = AdjPythWins(teamStats, i);

                // Check if the Win % came within 10% to the real win percentage, if it did keep track of the X value
                double perDiff = CalcPerDiff(pythWins, realWinPer);
                if (perDiff <= 10)
                {
                    potXVals.Add(i);
                }
            }
            // After the list has been created, take an average and use that as the X value
            double avg = 0;
            foreach (var num in potXVals)
                avg += num;
            avg /= potXVals.Count;

            return avg;
        }

        /// <summary>
        /// <para>
        ///
        /// This function will determine the percent difference of two given numbers.
        /// 
        /// </para>
        /// <para>
        /// 
        /// The formula is: ((n2 - n1) / n2) * 100
        /// 
        /// </para>
        /// </summary>
        /// <param name="numA">First number to compare.</param>
        /// <param name="numB">Second number to compare.</param>
        /// <returns name="perDiff">The percentage difference of the two numbers.</returns>
        public double CalcPerDiff(double numA, double numB)
        {
            double perDiff = 0;
            double n1;
            double n2;

            // First we need to see which number is bigger, and assign values accordingly
            if (numA > numB)
            {
                // n1 must always be the smaller number
                n1 = numB;
                // n2 must always be the bigger number
                n2 = numA;
            }
            else if (numB > numA)
            {
                // n1 must always be the smaller number
                n1 = numA;
                // n2 must always be the bigger number
                n2 = numB;
            }
            else
            {
                // They must be matching so the diff is 0
                return 0;
            }

            // Find the percent differene
            perDiff = ((n2 - n1) / n2) * 100;
            return perDiff;
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
        /// This function will use the adjusted Pythagorean Wins formula to get the given teams predicted win percentage.
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
            // Goals for is at pos = 8 in string csv
            int goalsFor = (int)GetStat(teamStats, 8);
            // Goal Against is at pos = 9 in string csv
            int goalsAgainst = (int)GetStat(teamStats, 9);

            // Get the best X Value to use
            double xValue = GetXValue(teamStats);

            // Math!
            double pythWins = (Math.Pow(goalsFor, xValue) / ((Math.Pow(goalsFor, xValue)) + (Math.Pow(goalsAgainst, xValue))));

            return pythWins;
        }
        /// <summary>
        /// <para>
        /// 
        /// This function will use the adjusted Pythagorean Wins formula to get the given teams predicted win percentage.
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
        /// <para>
        /// 
        /// This Method will be used in finding the best X value.
        /// 
        /// </para>
        /// </summary>
        /// <param name="teamStats">Line from CSV file to look through.</param>
        /// <param name="xValue">X value to test.</param>
        /// <returns></returns>
        public double AdjPythWins(string teamStats, double xValue)
        {
            // Goals for is at pos = 8 in string csv
            int goalsFor = (int)GetStat(teamStats, 8);
            // Goal Against is at pos = 9 in string csv
            int goalsAgainst = (int)GetStat(teamStats, 9);

            // Math!
            double pythWins = (Math.Pow(goalsFor, xValue) / ((Math.Pow(goalsFor, xValue)) + (Math.Pow(goalsAgainst, xValue))));

            return pythWins;
        }

        /// <summary>
        /// <para>
        ///
        /// This will find the Ratings Percentage Index of a team
        /// 
        /// </para>
        /// <para>
        /// 
        /// The formula is: RPI = (WP * 0.25) + (OWP * 0.5) + (OOWP * 0.25)
        /// 
        /// </para>
        /// <para>
        /// 
        /// Where: 
        /// RPI = Ratings Percentage Index | 
        /// WP = Winning Percentage of team | 
        /// OWP = Opponents Winning Percentage | 
        /// OOWP = Opponents Opponents Winning Percentage
        /// 
        /// </para>
        /// </summary>
        /// <param name="teamStats">Line from CSV file to look through.</param>
        /// <returns name="RPI">Calculated Ratings Percentage Index of the given team.</returns>
        public int RatingsPercentageIndex(string teamStats)
        {
            // First step is to calculate the winning percentage of the team
            // Luckily the winning percentage is a stat kept on index 7
            double teamWinPerc = GetStat(teamStats, 7);

            // Next we need to find the opponents winning percentage
            double oppWinPerc = 0.0;

            // Then we need to find the opponents opponents winning percentage
            double oppOppWinPerc = 0.0;

            // Now we calculate the Ratings Percentage Index of the given team.
            double RPI = (teamWinPerc * 0.25) + (oppWinPerc * 0.5) + (oppOppWinPerc * 0.25);

            return (int)RPI;
        }
    }
}
