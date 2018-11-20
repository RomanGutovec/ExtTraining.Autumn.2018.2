﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Entities
{
    public class CanonPrinter : Printer
    {
        public CanonPrinter()
        {
            Model = "231";
            Name = "Epson";
        }

        public CanonPrinter(string name, string model)
        {
            Model = name;
            Name = model;
        }

        public override void Print(FileStream fs)
        {
            for (int i = 0; i < fs.Length; i++)
            {
                // simulate printing
                System.Console.WriteLine(fs.ReadByte());
            }
        }

    }
}
