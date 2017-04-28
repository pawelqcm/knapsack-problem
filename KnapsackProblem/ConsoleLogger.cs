using System;

namespace KnapsackProblem
{
    internal class ConsoleLogger : Logger
    {
        public override void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
