using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet
{
    internal static class ColorSetter
    {
        public static readonly ConsoleColor Original;
        public const ConsoleColor Information = ConsoleColor.DarkCyan;
        public const ConsoleColor Error = ConsoleColor.Red;
        public const ConsoleColor Warning = ConsoleColor.Yellow;
        public const ConsoleColor Success = ConsoleColor.Green;

        static ColorSetter() { Original = Console.ForegroundColor; }

        public static void Write(string message, ConsoleColor nature)
        {
            Console.ForegroundColor = nature;
            Console.Write(message);
            Console.ForegroundColor = Original;
        }

        public static void WriteLine(string message, ConsoleColor nature)
        {
            Console.ForegroundColor = nature;
            Console.WriteLine(message);
            Console.ForegroundColor = Original;
        }
    }
}
