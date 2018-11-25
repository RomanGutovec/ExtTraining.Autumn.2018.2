using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using No8.Solution.Factory;

namespace No8.Solution
{
    public class PrinterManager
    {
        private readonly ILogger logger;        

        public PrinterManager(ILogger logger = null)
        {
            Printers = new List<Printer>();
            this.logger = logger ?? throw new ArgumentNullException($"Loger {nameof(logger)} haves null value");
        }

        public List<Printer> Printers { get; private set; }

        public void Add(Printer newPrinter)
        {
            if (newPrinter == null)
            {
                throw new ArgumentNullException($"Printer {nameof(newPrinter)} mustn't be null");
            }

            if (!Printers.Contains(newPrinter))
            {               
                Printers.Add(newPrinter);
                logger.Log($"Printer added ({newPrinter.Name} {newPrinter.Model})");
            }
        }
        
        public void Print(Printer printer, string name)
        {
            if (printer == null)
            {
                throw new ArgumentNullException($"Printer must be initialized");
            }

            logger.Log($"Printing started in {DateTime.Now}\n");
         
            using (FileStream fileStream = File.OpenRead(name))
            {
                printer.Print(fileStream);
            }           

            logger.Log($"Printing finished in {DateTime.Now}\n");            
        }        
    }
}
