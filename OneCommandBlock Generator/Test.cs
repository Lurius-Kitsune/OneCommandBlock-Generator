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
            //TESTE SI INIT ET MIT
            try
            {
                Console.WriteLine("[#1 TesteBuildInit]");
                OneCommandGenerator monOneCommand = new OneCommandGenerator("Mods de Lurius", "Voici un No mod", 2);

                List<string> initCommand = new List<string>();
                initCommand.Add("/setblock ~ ~5 ~ minecraft:diamond_block");
                Console.WriteLine($"[Info]{monOneCommand.OneCommandBuild(initCommand)}");
                Console.WriteLine("[# 1 SUCCESS]");
            }
            catch (Exception ex) { Console.WriteLine("[#1 ERROR]"); }

            // TEST WITHOUT INIT
            try
            {
                Console.WriteLine("[#2 TesteBuildInit]");
                OneCommandGenerator monOneCommand = new OneCommandGenerator("Mods de Lurius", "Voici un No mod", 2);

                List<string> initCommand = new List<string>();
                Console.WriteLine($"[Info]{monOneCommand.OneCommandBuild()}");
                Console.WriteLine("[#2 ERROR]");
            }
            catch (Exception ex) { Console.WriteLine("[#2 SUCCESS]" + ex.Message); }
        }
    }
}
