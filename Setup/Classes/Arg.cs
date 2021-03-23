using Mono.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Classes
{
    class Arg
    {
        public List<string> Parse(string[] args)
        {
            bool show_help = false;
            string tag = "";

            var p = new OptionSet() {
                { "h|help",  "show this message and exit",v => show_help = v != null },
                { "t|tag", "the Github Tag to check for.", v => tag = v}
            };
            List<string> extra;
            try
            {
                extra = p.Parse(args);
            }
            catch (OptionException e)
            {
                Console.Write("setup: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `setup --help' for more information.");
                List<string> error = new List<string>();
                error.Add(e.Message);
                return error;
            }

            if (show_help)
            {
                ShowHelp(p);
                return new List<string>
                {
                    ""
                };
            }
            return extra;
        }
        static void ShowHelp(OptionSet p)
        {
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }
    }
}
