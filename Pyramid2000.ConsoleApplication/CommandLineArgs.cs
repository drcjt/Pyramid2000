using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000.ConsoleApplication
{
    public class CommandLineArgs
    {
        private IDictionary<string, string> _args;

        public string AsString(string argName)
        {
            if (_args.ContainsKey(argName.ToLower(CultureInfo.InvariantCulture)))
            {
                return _args[argName.ToLower(CultureInfo.InvariantCulture)];
            }

            return "";
        }

        public bool AsBool(string argName)
        {
            if (_args.ContainsKey(argName.ToLower(CultureInfo.InvariantCulture)))
            {
                return Convert.ToBoolean(_args[argName.ToLower(CultureInfo.InvariantCulture)]);
            }

            return false;
        }

        public void ParseArgs(string[] args, string defaultArgs)
        {
            _args = new Dictionary<string, string>();
            ParseDefaults(defaultArgs);

            foreach (var arg in args)
            {
                ParseArg(arg);
            }
        }

        private void ParseDefaults(string defaultArgs)
        {
            if (!string.IsNullOrWhiteSpace(defaultArgs))
            {
                string[] args = defaultArgs.Split(';');

                foreach (var arg in args)
                {
                    ParseArg(arg);
                }
            }
        }

        private void ParseArg(string arg)
        {
            var words = arg.Split('=');
            var argKey = words[0].ToLower(CultureInfo.InvariantCulture);
            var argValue = words[1];
            _args[argKey] = argValue;
        }
    }
}
