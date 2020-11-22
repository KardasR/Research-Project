using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research_Project
{
    class FindBestX
    {
        // Let's us use all of our custom methods.
        Methods methods = new Methods();
        List<double> xVals = new List<double>();
        double bestX = 0;
        public double BestXFinder(string path)
        {
            // Used to read the CSV file.
            using (StreamReader sr = new StreamReader(path))
            {
                // Skip the first line as it's just a header.
                string currentLine = sr.ReadLine();

                // Look line by line until the EOF.
                while ((currentLine = sr.ReadLine()) != null)
                {
                    xVals.Add(methods.GetXValue(currentLine));
                }
            }

            // Get the average X value to determine the best X
            foreach (var xVal in xVals)
                bestX += xVal;
            bestX /= xVals.Count;

            return bestX;
        }
    }
}
