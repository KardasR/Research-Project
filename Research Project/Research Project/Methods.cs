using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        /// <para>
        /// 
        /// This will collect all stat lines from a file except from the specified team.
        /// 
        /// </para>
        /// </summary>
        /// <param name="teamName">Name of team to ignore.</param>
        /// <param name="path">Path of the CSV file to look at.</param>
        /// <returns name="otherTeamStats">List containing lines from CSV of teams without specified team.</returns>
        public List<string> GetOtherTeamStats(string teamName, string path)
        {
            List<string> otherTeamStats = new List<string>();

            // Used to read the CSV file.
            using (StreamReader sr = new StreamReader(path))
            {
                // Skip the first line as it's just a header.
                string currentLine = sr.ReadLine();

                // Look line by line until the EOF.
                while ((currentLine = sr.ReadLine()) != null)
                {
                    // Search for 'teamName' in current line. If it's not there, add the line to list.
                    if (!(currentLine.IndexOf(teamName, StringComparison.CurrentCultureIgnoreCase) >= 0))
                    {
                        otherTeamStats.Add(currentLine);
                    }
                }
                
                // There should never not be a match for a given team name. But if there is the program will return this to avoid an error.
                return otherTeamStats;
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
        /// Retrieve individual string stat of a team.
        /// 
        /// </para>
        /// </summary>
        /// <param name="teamStats">Line from CSV file to look through.</param>
        /// <param name="statPos">Position in the CSV line of the stat. (Team Name, Opponent Name, etc.)</param>
        /// <returns name="stat">Individual stat that was requested.</returns>
        public string GetStringStat(string teamStats, int statPos)
        {
            // Split the given string into an array and return the value in the given position.
            string[] stats = teamStats.Split(',');
            string stat = stats[statPos];
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
        /// Add up all of the given stats and return the average of the stats.
        /// 
        /// </para>
        /// </summary>
        /// <param name="stats">List of stats to average.</param>
        /// <param name="statPos">The position of the stat needed to be averaged.</param>
        /// <returns name="avgOfStats">The average of the stats.</returns>
        public double GetAvgOfStats(List<string> stats, int statPos)
        {
            double avgOfStats = 0.0;
            int count = 0;

            foreach (string statLine in stats)
            {
                double stat = GetStat(statLine, statPos);
                avgOfStats += stat;
                count++;
            }

            avgOfStats /= count;

            return avgOfStats;
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
            if (!(potXVals.Count == 0))
            {
                foreach (var num in potXVals)
                    avg += num;
                avg /= potXVals.Count;
            }
            else
                avg = 2;     // Use the default value of 2 incase there are no matches found.

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
        /// This will get the normalized data from any given double array.
        /// 
        /// </para>
        /// </summary>
        /// <param name="data">Data to be normalized.</param>
        /// <returns name="normVal">Sum of normalized data.</returns>
        public double NormalizeData(double[] data)
        {
            double maxValue = data.Max();
            double normVal = 0;

            // Loop through every item in the array and divide by the max, add this to the holder variable to return.
            foreach (double val in data)
            {
                double hold = val / maxValue;
                normVal += hold;
            }

            return normVal;
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
        /// This will find the Ratings Percentage Index of a given team.
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
        /// <param name="path">Path of the CSV file to look at.</param>
        /// <returns name="RPI">Calculated Ratings Percentage Index of the given team.</returns>
        public double RatingsPercentageIndex(string teamStats, string path)
        {
            // First step is to calculate the winning percentage of the team
            // Luckily the winning percentage is a stat kept on index 7
            double teamWinPerc = GetStat(teamStats, 7);

            // Next we need to find the opponents winning percentage
            double oppWinPerc = OppWinPer(teamStats, path);

            // Then we need to find the opponents opponents winning percentage
            double oppOppWinPerc = OppOppWinPer(teamStats, path);

            // Now we calculate the Ratings Percentage Index of the given team.
            double RPI = (teamWinPerc * 0.25) + (oppWinPerc * 0.5) + (oppOppWinPerc * 0.25);

            return RPI;
        }

        /// <summary>
        /// <para>
        /// 
        /// This will get the Opponents Winning Percentage. This is esentially the combined Win Percentage of every team 
        /// in the league, not including the given team.
        /// 
        /// </para>
        /// </summary>
        /// <param name="teamStats">Line from CSV file to look through.</param>
        /// <param name="path">Path of the CSV file to look at.</param>
        /// <returns name="avgWP">Opponents Winning Percentage</returns>
        public double OppWinPer(string teamStats, string path)
        {
            double avgWP = 0.0;

            // First we need to get the name of the given team.
            // Team names are located at the first index.
            string teamName = GetStringStat(teamStats, 0);

            // Then, we need to look through the given CSV and only save the lines that DON'T include the given team name.
            List<string> oppTeamStats = GetOtherTeamStats(teamName, path);

            // After that, we need to take out and average the Winning Percentage for each team.
            // Winning Percentage is a stat kept on index 7
            avgWP = GetAvgOfStats(oppTeamStats, 7);

            // Finally, we can return the result.
            return avgWP;
        }

        /// <summary>
        /// <para>
        /// 
        /// This will get the Opponents Opponents Winning Percentage. This is the combined Win Percentage of every team
        /// in the league and their opponents, not including the given team.
        /// 
        /// </para>
        /// </summary>
        /// <param name="teamStats">Line from CSV file to look through.</param>
        /// <param name="path">Path of the CSV file to look at.</param>
        /// <returns name="avgWP">Opponents Opponents Winning Percentage.</returns>
        public double OppOppWinPer(string teamStats, string path)
        {
            double avgWP = 0.0;
            int count = 0;

            // First we need to get the name of the given team.
            // Team names are located at the first index.
            string teamName = GetStringStat(teamStats, 0);

            // Then, we need to look through the given CSV and only save the lines that DON'T include the given team name.
            List<string> oppTeamStats = GetOtherTeamStats(teamName, path);

            // Now we loop through the list and add up all of the win percentages against teams not including the given team and their opponents.
            foreach (string teamStat in oppTeamStats)
            {
                string otherTeamName = GetStringStat(teamStat, 0);
                List<string> oppOppTeamStats = GetOtherTeamStats(otherTeamName, path);
                oppOppTeamStats.Remove(teamStats);
                avgWP += GetAvgOfStats(oppOppTeamStats, 7);
                count++;
            }

            // Calculate and return the average Win Percentage.
            avgWP /= count;

            return avgWP;
        }

        /// <summary>
        /// <para>
        /// 
        /// This will get the special teams percentage of the given team.
        /// 
        /// </para>
        /// <para>
        /// 
        /// This is calculated through the formula, OPP% + OPK%. 
        /// 
        /// </para>
        /// <para>
        /// 
        /// Where: 
        /// OPP% = Overall Powerplay Percentage | 
        /// OPK% = Overall Penalty Killing Percentage
        /// 
        /// </para>
        /// 
        /// Link to the website that I got this from.
        /// https://nathangabay.com/you-down-with-opp-and-other-special-teams-metrics/
        /// 
        /// </summary>
        /// <param name="teamStats">Line from CSV file to look through.</param>
        /// <returns></returns>
        public double GetSTPer(string teamStats)
        {
            double stPercentage = 0.0;
            double ppGF = GetStat(teamStats, 13);    // Powerplay Goals For is located at index 13
            double ppGA = GetStat(teamStats, 16);    // Powerplay Goals Against is located at index 16
            double ppOp = GetStat(teamStats, 14);    // Powerplay Opportunities is located at index 14
            double pkGF = GetStat(teamStats, 19);    // Penalty Kill Goals For is located at index 19
            double pkGA = GetStat(teamStats, 20);    // Penalty Kill Goals Against is located at index 20
            double pkOp = GetStat(teamStats, 17);    // Penalty Kill Opportunities is located at index 17

            double OPP = (ppGF - ppGA) / ppOp;
            double OPK = (pkGA - pkGF) / pkOp;

            stPercentage = OPP + OPK;

            return stPercentage;
        }

        /// <summary>
        /// <para>
        /// 
        /// This will calulate a teams even strength ability specifically looking at 
        /// statistics that are not influenced by special teams.
        /// 
        /// </para>
        /// <para>
        /// 
        /// This is calculated through the formula, (CF% * SV%) + S%
        /// 
        /// </para>
        /// <para>
        /// 
        /// Where: 
        /// CF% = Corsi For Percentage | 
        /// SV% = Save Percentage | 
        /// S%  = Shooting Percentage
        /// 
        /// </para>
        /// </summary>
        /// <param name="teamStats">Line from CSV file to look through.</param>
        /// <returns name="evenStrat">The given teams even strength ability.</returns>
        public double EvenAbil(string teamStats)
        {
            double corsiForPer = GetStat(teamStats, 27);        // Corsi For % is located at index 27
            double savePer = GetStat(teamStats, 28);            // Save % is located at index 28
            double shootingPer = GetStat(teamStats, 29);        // Shooting % is located at index 29

            double evenStrat = (corsiForPer * savePer) + shootingPer;   // I custom made this so let's hope it's accurate haha

            return evenStrat;
        }

        public double SDM(string teamStats, string season2017, string season2018, string season2019)
        {
            string teamName = GetStringStat(teamStats, 0);

            // Create arrays to store all of the stats.
            double[] RPIs = new double[3];
            double[] APWs = new double[3];
            double[] STPs = new double[3];
            double[] EAs = new double[3];

            // Get the stats for the 2016-2017 season.
            string teamStats2017 = GetTeamStats(teamName, season2017);
            RPIs[0] = RatingsPercentageIndex(teamStats2017, season2017);
            APWs[0] = AdjPythWins(teamStats2017);
            STPs[0] = GetSTPer(teamStats2017);
            EAs[0] = EvenAbil(teamStats2017);

            // Get the stats for the 2017-2018 season.
            string teamStats2018 = GetTeamStats(teamName, season2018);
            RPIs[1] = RatingsPercentageIndex(teamStats2018, season2018);
            APWs[1] = AdjPythWins(teamStats2018);
            STPs[1] = GetSTPer(teamStats2018);
            EAs[1] = EvenAbil(teamStats2018);

            // Get the stats for the 2018-2019 season.
            string teamStats2019 = GetTeamStats(teamName, season2019);
            RPIs[2] = RatingsPercentageIndex(teamStats2019, season2019);
            APWs[2] = AdjPythWins(teamStats2019);
            STPs[2] = GetSTPer(teamStats2019);
            EAs[2] = EvenAbil(teamStats2019);

            // Normalize all the data.
            double normRPI = NormalizeData(RPIs);
            double normAPW = NormalizeData(APWs);
            double normSTP = NormalizeData(STPs);
            double normEA = NormalizeData(EAs);

            // This is the math for the method.
            return normRPI + normAPW + normSTP + normEA;
        }
    }
}
