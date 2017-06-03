using System;
using System.Collections.Generic;
using System.IO;

namespace KnapsackProblem
{
    internal class FileInput : Input
    {
        public void Fill(string file)
        {
            var delimiters = new[]
            {
                ' ',
                '-',
                ':',
                ';'
            };

            try
            {
                using (
                    var sr =
                        new StreamReader(
                            Path.Combine(
                                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                                file)))
                {
                    string line;
                    var index = 0;
                    var delimiter = ' ';
                    while ((line = sr.ReadLine()) != null)
                    {
                        foreach (var d in delimiters)
                        {
                            if (line.Contains(d.ToString()))
                            {
                                delimiter = d;
                            }
                        }
                        var vals = line.Split(delimiter);
                        if (vals.Length != 2)
                            throw new FormatException("File input in wrong format - exactly 2 values in single line expected");

                        double v1, v2;
                        if (double.TryParse(vals[0], out v1) && double.TryParse(vals[1], out v2))
                        {
                            Items.Add(index, new KeyValuePair<double, double>(v1, v2));
                            index++;
                        }
                        else
                            throw new FormatException("File input in wrong format - cannot parse input as a number");
                    }
                }

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Cannot load file - check file name/location");
                throw;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
