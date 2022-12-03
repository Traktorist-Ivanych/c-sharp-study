using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox8_6
{
    class Program
    {

        static void Main(string[] args)
        {
            WorkWithLists workWithLists = new WorkWithLists();
            WorkWithDictionary workWithDictionary = new WorkWithDictionary();
            WorkWithHashSet workWithHashSet = new WorkWithHashSet();
            WorkWithXml workWithXml = new WorkWithXml();

            workWithLists.StartProcess();

            workWithDictionary.StartProcess();

            workWithHashSet.StartProcess();

            workWithXml.StartProcess();

            Console.ReadKey();
        }
    }
}
