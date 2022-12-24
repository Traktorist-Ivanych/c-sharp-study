using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox15_06_Library
{
    public static class Extensions
    {
        public static void Print<T>(this T value)
            where T : struct
        {
            Console.WriteLine(value);
        }
    }
}
