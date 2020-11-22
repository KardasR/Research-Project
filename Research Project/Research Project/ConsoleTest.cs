using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research_Project
{
    class ConsoleTest
    {
        public void tester()
        {
            // Location of our csv file.
            string stats2019path = "/home/kardasr/Programming/testproject/ConsoleApp1/ConsoleApp1/2018-2019teamStats.csv";

            // Team names that 
            string teamAname = "Detroit Red Wings";
            string teamBname = "Anaheim Ducks";

            // Let's us use all of our custom methods.
            Methods methods = new Methods();
            FindBestX findBestX = new FindBestX();

            // Get the stats for the two teams.
            string teamAStats = methods.GetTeamStats(teamAname, stats2019path);
            string teamBStats = methods.GetTeamStats(teamBname, stats2019path);
            double teamArealWinPerc = methods.GetStat(teamAStats, 7);
            double teamBrealWinPerc = methods.GetStat(teamBStats, 7);

            // Get the Original Pythagorean Wins for each team.
            double teamAogPW = methods.OrigPythWins(teamAStats);
            double teamBogPW = methods.OrigPythWins(teamBStats);

            // Get the Adjusted Pythagorean Wins for each team.
            double teamAadjPW = methods.AdjPythWins(teamAStats);
            double teamBadjPW = methods.AdjPythWins(teamBStats);

            // Get the Percentage Difference for each prediction
            double teamAogPD = methods.CalcPerDiff(teamAogPW, teamArealWinPerc);
            double teamBogPD = methods.CalcPerDiff(teamBogPW, teamBrealWinPerc);
            double teamAadjPD = methods.CalcPerDiff(teamAadjPW, teamArealWinPerc);
            double teamBadjPD = methods.CalcPerDiff(teamBadjPW, teamBrealWinPerc);

            // Get the best X Value for adjusted Pythagorean Wins
            double bestX = findBestX.BestXFinder(stats2019path);

            // Output the results.

            // Team A output
            Console.WriteLine("---------- " + teamAname + " stats ----------");
            Console.WriteLine("Real Win %: " + teamArealWinPerc);
            Console.WriteLine("Original Pythagorean Wins Predicted %: " + teamAogPW);
            Console.WriteLine("Percentage Difference for Original Pythagorean Wins: " + teamAogPD);
            Console.WriteLine("Adjusted Pythagorean Wins Predicted %: " + teamAadjPW);
            Console.WriteLine("Percentage Difference for Adjusted Pythagorean Wins: " + teamAadjPD);

            // Team B output
            Console.WriteLine("---------- " + teamBname + " stats ----------");
            Console.WriteLine("Real Win %: " + teamBrealWinPerc);
            Console.WriteLine("Original Pythagorean Wins Predicted %: " + teamBogPW);
            Console.WriteLine("Percentage Difference for Original Pythagorean Wins: " + teamBogPD);
            Console.WriteLine("Adjusted Pythagorean Wins Predicted %: " + teamBadjPW);
            Console.WriteLine("Percentage Difference for Adjusted Pythagorean Wins: " + teamBadjPD);

            // Other Output
            Console.WriteLine("---------- Other Stats ----------");
            Console.WriteLine("Best X: " + bestX);
        }
    }
}
