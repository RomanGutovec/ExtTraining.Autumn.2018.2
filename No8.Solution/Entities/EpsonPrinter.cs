using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Entities
{
    public class EpsonPrinter : Printer
    {
        public EpsonPrinter()
        {
            this.Model = "231";
            this.Name = "Epson";
        }

        public EpsonPrinter(string name, string model)
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
