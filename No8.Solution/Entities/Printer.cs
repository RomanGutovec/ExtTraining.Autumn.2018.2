using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public abstract class Printer : IEquatable<Printer>
    {
        public event EventHandler<EventArgs> StartPrint = delegate { };

        public event EventHandler<EventArgs> EndPrint = delegate { };

        public string Name { get; set; }

        public string Model { get; set; }

        public bool Equals(Printer other)
        => this.Name == other.Name && this.Model == other.Model;

        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            return this.Equals((Printer)obj);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = (hash * 31) + Name.GetHashCode();
            hash = (hash * 31) + Model.GetHashCode();
            return hash;
        }

        public void Print(FileStream stream)
        {
            OnStartPrint(this, new PrintEventArgs("Printing started."));
            ConcretePrint(stream);
            OnEndPrint(this, new PrintEventArgs("Printing finished."));
        }

        protected abstract void ConcretePrint(FileStream fs);

        protected virtual void OnStartPrint(object sender, PrintEventArgs e)
        {
            StartPrint?.Invoke(this, e);
        }

        protected virtual void OnEndPrint(object sender, PrintEventArgs e)
        {
            EndPrint?.Invoke(this, e);
        }
    }
}
