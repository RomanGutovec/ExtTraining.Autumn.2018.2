using System;
using No8.Solution.Factory;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace No8.Solution.Console
{
    public class PrinterManager
    {
        //TODO
        //public delegate void PrinterDelegate(string arg);


        private readonly ILogger logger;


        public PrinterManager(ILogger logger)
        {
            Printers = new List<Printer>();

            this.logger = logger ?? throw new ArgumentNullException($"Loger {nameof(logger)} haves null value");
        }

        ///TODO
        public PrinterManager(AbstractFactoryPrinters printer, ILogger logger)
        {
            Printers = new List<Printer>();
            if (printer == null)
            {
                throw new ArgumentNullException($"Printer {nameof(printer)} can not be null");
            }

            printer.CreatePrinter();
            this.logger = logger ?? throw new ArgumentNullException($"Loger {nameof(logger)} haves null value");
        }

        public event EventHandler<PrintEventArgs> Printed = delegate { };

        public List<Printer> Printers { get; set; }

        public void Add(Printer newPrinter)
        {
            if (newPrinter == null)
            {
                throw new ArgumentNullException($"Printer {nameof(newPrinter)} mustn't be null");
            }

            ///TODO 
            if (!Printers.Contains(newPrinter))
            {
                Printers.Add(newPrinter);
            }
        }

        public void Print(Printer printer)
        {
            logger.Log($"Print started in {DateTime.Now}\n");

            OnPrinted(this, new PrintEventArgs("Print started"));

            var dialogWindow = new OpenFileDialog();
            dialogWindow.ShowDialog();
            var fileDialog = File.OpenRead(dialogWindow.FileName);

            printer.Print(fileDialog);

            logger.Log($"Print finished in {DateTime.Now}\n");
            OnPrinted(this, new PrintEventArgs("Print finished"));
        }

        protected virtual void OnPrinted(object sender, PrintEventArgs e)
        {
            Printed?.Invoke(this, e);
        }

    }
}
