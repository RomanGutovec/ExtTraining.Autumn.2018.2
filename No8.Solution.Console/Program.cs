using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.Console.Helpers;
using No8.Solution.Entities;
using No8.Solution.Factory;

namespace No8.Solution.Console
{
    class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            PrinterManager manager = new PrinterManager(new Logger());
            manager.Add(new EpsonPrinter());
            manager.Add(new CanonPrinter());

            while (true)
            {
                if (Work(manager) == 0)
                {
                    break;
                }
            }

        }

        private static int Work(PrinterManager printerManager)
        {
            System.Console.WriteLine($"Select your choice:\n" +
                $"1: Add new printer\n" +
                $"2: Print on canon\n" +
                $"3: Print on epson\n" +
                $"0: Exit\n");
            int.TryParse(System.Console.ReadLine(), out int choice);
            if (choice == 1)
            {
                System.Console.WriteLine("Enter printer name");
                string namePrinter = System.Console.ReadLine();
                System.Console.WriteLine("Enter printer model");
                string printerModel = System.Console.ReadLine();

                if (namePrinter.Equals("Canon", StringComparison.CurrentCultureIgnoreCase))
                {
                    printerManager.Add(new EpsonPrinter(namePrinter, printerModel));
                }

                if (namePrinter.Equals("Epson", StringComparison.CurrentCultureIgnoreCase))
                {
                    printerManager.Add(new CanonPrinter(namePrinter, printerModel));
                }

                ShowPrinters(printerManager.Printers);
            }
             else if (choice == (int)KindOfPrinter.Canon)
            {
                string kindOfPrinter = "Canon";
                NewMethod(printerManager, kindOfPrinter);
            }
            else if (choice == (int)KindOfPrinter.Epson)
            {
                string kindOfPrinter = "Epson";
                NewMethod(printerManager, kindOfPrinter);
            }

            return choice;
        }

        private static void NewMethod(PrinterManager printerManager, string kindOfPrinter)
        {
            System.Console.WriteLine("Choose number printer which you would like use to print");
            List<Printer> concretePrinters = new List<Printer>(printerManager.Printers.Where(x => x.Name == kindOfPrinter));
            ShowPrinters(concretePrinters);
            int result;
            int.TryParse(System.Console.ReadLine(), out result);
            while (true)
            {
                if (result > concretePrinters.Count || result < 0)
                {
                    System.Console.WriteLine("Incorrect input, try again...");
                }
                else
                {
                    printerManager.Print(printerManager.Printers.Find(x => x.Name == concretePrinters[result - 1].Name && x.Model == concretePrinters[result - 1].Model));
                    break;
                }
            }
        }

        private static void ShowPrinters(IEnumerable<Printer> printers)
        {
            int index = 1;
            foreach (var concretePrinter in printers)
            {
                System.Console.WriteLine($"{index++}: {concretePrinter.Name} {concretePrinter.Model}");
            }
        }
    }
}
