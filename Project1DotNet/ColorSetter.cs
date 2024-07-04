using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet
{
    internal static class ColorSetter
    {
        public static readonly ConsoleColor originalForegroundColor;
        public static readonly ConsoleColor originalBackgroundColor;

        static ColorSetter()
        {
            originalForegroundColor = Console.ForegroundColor;
            originalBackgroundColor = Console.BackgroundColor;
        }

        public static void InformationColor()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }

        public static void ErrorColor()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public static void WarningColor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public static void SuccessColor()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void Reset()
        {
            Console.ForegroundColor = originalForegroundColor;
        }
    }
}
