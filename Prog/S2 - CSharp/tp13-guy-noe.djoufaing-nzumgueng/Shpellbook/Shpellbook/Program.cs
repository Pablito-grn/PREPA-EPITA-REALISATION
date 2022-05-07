using System;
using System.IO;

namespace Shpellbook
{
    public class Program
    {
        public static void Run(TextReader input, bool isConsole)
        {
            var parser = new Parser(input);
            while (true)
            {
                if (isConsole)
                    Console.Write("Shpellbook$ ");
                
                var cmd = parser.ParseInput();
                
                if (cmd == null)
                    break;

                if (cmd.args.Length != 0 && cmd.args[0] != "")
                {
                    var code = Eval.Evaluate(cmd);

                    if (code == -1)
                        Console.WriteLine( "Program is running in background");
                    else
                        Console.WriteLine( "Command ended with value "+ code);
                }
                
                Eval.UpdateJobs();
            }
        }

        public static void Main(string[] args)
        {
            Run(Console.In, true);
        }
    }
}