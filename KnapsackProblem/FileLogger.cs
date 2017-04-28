using System;
using System.IO;

namespace KnapsackProblem
{
    internal class FileLogger : Logger
    {
        private readonly string _filename;

        public FileLogger()
        {
            var location = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            _filename = Path.Combine(location, $"log_{timestamp}.txt");
        }

        public override void Log(string message)
        {
            using (var writer = new StreamWriter(_filename, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }

}
