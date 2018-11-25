using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public class PrintEventArgs : EventArgs
    {
        public PrintEventArgs(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }
    }
}
