using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public abstract class Printer
    {
        public string Name { get; set; }

        public string Model { get; set; }

        public abstract void Print(FileStream fs);
    }
}
