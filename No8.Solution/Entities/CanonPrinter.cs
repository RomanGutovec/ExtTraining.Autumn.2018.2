using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Entities
{
    public class CanonPrinter : Printer
    {
        public CanonPrinter()
        {
            this.Name = "Canon";
            this.Model = "231";
        }

        public CanonPrinter(string name, string model)
        {
            this.Name = name;
            this.Model = model;
        }

        public override void Print(FileStream fs)
        {
            for (int i = 0; i < fs.Length; i++)
            {
                 System.Console.WriteLine(fs.ReadByte());
            }
        }
    }
}
