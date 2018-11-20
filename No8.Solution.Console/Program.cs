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

            System.Console.ReadLine();
        }

        private static int Work(PrinterManager printerManager)
        {
            System.Console.WriteLine($"Select your choice:\n" +
                $"1: Add new printer\n" +
                $"2: Print on canon\n" +
                $"3: Print on epson\n" +
                $"0: Exit\n");
            int choice = 0;
            int.TryParse(System.Console.ReadLine(), out choice);

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

                return choice;
            }
            else if (choice == 0)
            {
                return choice;
            }
            else
            {
                //TODO
                printerManager.Print(printerManager.Printers[choice - 2]);
                return choice;
            }
        }
    }
}
