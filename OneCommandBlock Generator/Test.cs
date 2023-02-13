using OneCommandBlock_Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outils
{
    class Test
    {
        static void Main(string[] args)
        {
            TesteBuildInitOnly();
            Console.ReadKey();
        }

        public static void TesteBuildInitOnly()
        {
            Generator monOneCommand = new Generator("Mods de Lurius", "Voici un No mod");

            List<string> initCommand = new List<string>();
            initCommand.Add("/say hello");
            Console.WriteLine($"[Info]{monOneCommand.OneCommandBuild(initCommand)}");
        }
    }
}
