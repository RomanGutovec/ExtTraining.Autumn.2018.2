using No8.Solution;
using No8.Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Factory
{
    public class AbstractPrinterEpson: AbstractFactoryPrinters
    {
        public override Printer CreatePrinter()
        {
            return new EpsonPrinter();
        }
    }
}
