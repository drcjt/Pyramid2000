using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000.Engine
{
    public class Printer : IPrinter
    {
        IPrinter _printer;
        bool _trs80Mode;

        public Printer(IPrinter printer, bool trs80Mode = true)
        {
            _printer = printer;
            _trs80Mode = trs80Mode;
        }

        public void Print(string text)
        {
            _printer.Print(FormatText(text));
        }

        public void PrintLn(string text)
        {
            _printer.PrintLn(FormatText(text));
        }

        private string FormatText(string text)
        {
            if (_trs80Mode)
            {
                return text.Replace(". ", ".  ");
            }
            else
            {
                return text;
            }
        }
    }
}
