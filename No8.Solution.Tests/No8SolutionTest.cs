using System;
using No8.Solution.Entities;
using NUnit.Framework;

namespace No8.Solution.Tests
{
    [TestFixture]
    public class No8SolutionTest
    {
        [Test]
        public void CtorTest_DefaultCtor_EmptyListOfPrintersByDefault()
        {
            PrinterManager manager = new PrinterManager();
            Assert.IsEmpty(manager.Printers);
        }

        [Test]
        public void AddTest_AddMOdel1_Model2_Model3()
        {
            PrinterManager manager = new PrinterManager();
            Printer[] printerArray = { new CanonPrinter("Canon", "model1"), new CanonPrinter("Canon", "model2"), new EpsonPrinter("Epson", "model3") };
            foreach (var item in printerArray)
            {
                manager.Add(item);
            }

            int i = 0;
            foreach (var item in manager.Printers)
            {
                Assert.AreEqual(printerArray[i++].Model, item.Model);
            }
        }

        [Test]
        public void AddTestIfAlreadyExist_AddMOdel1_Model2_Model3()
        {
            PrinterManager manager = new PrinterManager();
            Printer[] printerArray = { new CanonPrinter("Canon", "model1"), new CanonPrinter("Canon", "model2"), new EpsonPrinter("Epson", "model3") };

            foreach (var item in printerArray)
            {
                manager.Add(item);
            }

            manager.Add(new CanonPrinter("Canon", "model1"));
            manager.Add(new CanonPrinter("Canon", "model2"));
            int i = 0;
            foreach (var item in manager.Printers)
            {
                Assert.AreEqual(printerArray[i++].Model, item.Model);
            }
        }

        [Test]
        public void AddTest_AddNullElement_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new PrinterManager().Add(null));
    }
}
