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
            this.Name = "Epson";
        }

        public EpsonPrinter(string model) : this()
        {
            this.Model = model;
        }

        public EpsonPrinter(string name, string model) : this(model)
        {
            this.Name = name;
            this.Model = model;
        }

        protected override void ConcretePrint(FileStream fs)
        {
            for (int i = 0; i < fs.Length; i++)
            {
                System.Console.WriteLine(fs.ReadByte());
            }
        }
    }
}
