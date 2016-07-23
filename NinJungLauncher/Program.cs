using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;
using NInJung;

namespace NinJungLauncher
{
    class Options
    {
        [Option('u', "unstrict", DefaultValue = false, HelpText = "Interpreted as unstrict mode.")]
        public bool Unstrict
        {
            get;
            set;
        }
        [Option('p',"path", Required = true, HelpText = "File path.")]
        public string Path
        {
            get;
            set;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var option = new Options();
            var helpText = HelpText.AutoBuild(option);
            helpText.Copyright = CopyrightInfo.Default + " SteamB23";
            if (Parser.Default.ParseArguments(args, option))
            {
                new NInJung.ScriptEngine((option.Unstrict ? ScriptEngineMode.Unstrict : ScriptEngineMode.Strict)).ExecuteFromFile(option.Path);
            }
            else
            {
                Console.WriteLine(helpText);
            }
        }
    }
}
