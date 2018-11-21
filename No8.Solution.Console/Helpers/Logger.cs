using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Console.Helpers
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            using (var stream = File.AppendText("log.txt"))
            {
                stream.Write(message+Environment.NewLine);
            }
        }
    }
}
