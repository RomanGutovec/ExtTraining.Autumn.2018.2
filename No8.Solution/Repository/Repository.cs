using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Repository
{
    public class PrinterRepository : IRepository<Printer>
    {
        private List<Printer> printers;
      
        public PrinterRepository()
        {
            printers = new List<Printer>(); 
        }

        public void Add(Printer item)
        {
            printers.Add(item);
        }

        public void Delete(string model)
        {
            printers.Remove(printers.Find(x => x.Model == model));
        }

        public Printer GetItem(string model)
        {
            return printers.Find(x => x.Model == model);
        }

        public IEnumerable<Printer> GetItemList()
        {
            return printers;
        }        
    }
}
