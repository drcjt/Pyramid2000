using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.Engine
{
    public class Printer : IPrinter
    {
        IPrinter _printer;
        IGameSettings _settings;

        public Printer(IPrinter printer, IGameSettings settings)
        {
            _printer = printer;
            _settings = settings;
        }

        public void Print(string text)
        {
            _printer.Print(FormatText(text));
        }

        public void PrintLn(string text)
        {
            _printer.PrintLn(FormatText(text));
        }

        public void Clear()
        {
            _printer.Clear();
        }

        private string FormatText(string text)
        {
            var formattedText = text;
            if (_settings.Trs80Mode) formattedText = formattedText.Replace(". ", ".  ");
            if (_settings.AllCaps) formattedText = formattedText.ToUpper();
            return formattedText;
        }
    }
}
