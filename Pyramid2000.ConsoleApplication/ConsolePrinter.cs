using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pyramid2000.Engine;

namespace Pyramid2000.ConsoleApplication
{
    class ConsolePrinter : IPrinter
    {
        public void PrintLn(string text)
        {
            Console.WriteLine(text);
        }

        public void Print(string text)
        {
            Console.Write(text);
        }
    }
}
