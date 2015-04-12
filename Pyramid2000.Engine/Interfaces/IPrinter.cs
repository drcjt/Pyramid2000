using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000.Engine.Interfaces
{
    public interface IPrinter
    {
        void PrintLn(string text);
        void Print(string text);
        void Clear();
    }
}
