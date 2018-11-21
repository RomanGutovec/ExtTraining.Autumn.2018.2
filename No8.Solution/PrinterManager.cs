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
        private readonly IRepository<Printer> printerRepository;

        public PrinterManager(ILogger logger = null)
        {
            Printers = new List<Printer>();
        }

        public PrinterManager(AbstractCreatorPrinters printer, ILogger logger)
        {
            if (printer == null)
            {
                throw new ArgumentNullException($"Printer {nameof(printer)} can not be null");
            }

            Printers = new List<Printer>();
            Printers.Add(printer.CreatePrinter());
            this.logger = logger ?? throw new ArgumentNullException($"Loger {nameof(logger)} haves null value");
        }

        public PrinterManager(AbstractCreatorPrinters printer, ILogger logger, IRepository<Printer> repository)
        {
            if (printer == null)
            {
                throw new ArgumentNullException($"Printer {nameof(printer)} can not be null");
            }

            this.printerRepository = repository ?? throw new ArgumentNullException($"Repository {nameof(repository)} haves null value");
            printerRepository.Add(printer.CreatePrinter());
            this.logger = logger ?? throw new ArgumentNullException($"Loger {nameof(logger)} haves null value");
        }

        public event EventHandler<PrintEventArgs> Printed = delegate { };

        public List<Printer> Printers { get; private set; }

        public void Add(Printer newPrinter)
        {
            if (newPrinter == null)
            {
                throw new ArgumentNullException($"Printer {nameof(newPrinter)} mustn't be null");
            }

            if (Printers.TrueForAll(x => x.Model != newPrinter.Model))
            {
                Printers.Add(newPrinter);
            }
        }

        public void Print(Printer printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException($"Printer must be initialized");
            }

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
