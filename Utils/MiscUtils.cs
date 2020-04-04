using System;

namespace UONETAutoRead.Utils
{
    class MiscUtils
    {
        public static void PrintFormatted(string s)
        {
            var z = DateTime.Now;
            Console.WriteLine($"[{z}] {s}");
        }
    }
}
