using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.Entities;

namespace No8.Solution.Factory
{
    public class PrinterFactory
    {
        public Printer CreatePrinter(string name, string model)
        {
            if (name == null)
            {
                throw new ArgumentNullException($"Name of the printer {nameof(name)} haves null value");
            }

            if (model == null)
            {
                throw new ArgumentNullException($"Name of the printer {nameof(model)} haves null value");
            }

            switch (name)
            {
                case "Canon":
                    return new CanonPrinter(model);
                case "Epson":
                    return new EpsonPrinter(model);
                default:
                    throw new ArgumentException($"Name of printer {nameof(name)} incorrect");
            }
        }
    }
}
