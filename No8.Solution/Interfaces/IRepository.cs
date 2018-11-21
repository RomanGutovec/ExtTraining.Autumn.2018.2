using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetItemList();

        T GetItem(string model);

        void Add(T item);

        void Delete(string model);
    }
}
