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
            //TesteBuildInitOnly();
            TesteBuildLoopOnly();
            Console.ReadKey();
        }

        public static void TesteBuildInitOnly()
        {
            //TESTE SI INIT ET MIT
            try
            {
                Console.WriteLine("[#1 TesteBuildInit]");
                OneCommandGenerator monOneCommand = new OneCommandGenerator("Mods de Lurius", "Voici un No mod", 3, 3);

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
                OneCommandGenerator monOneCommand = new OneCommandGenerator("Mods de Lurius", "Voici un No mod", 3, 3);

                List<string> initCommand = new List<string>();
                Console.WriteLine($"[Info]{monOneCommand.OneCommandBuild()}");
                Console.WriteLine("[#2 ERROR]");
            }
            catch (Exception ex) { Console.WriteLine("[#2 SUCCESS]" + ex.Message); }
        }

        public static void TesteBuildLoopOnly()
        {
            //TESTE SI INIT ET MIT
            try
            {
                Console.WriteLine("[#3 TesteBuildLoop]");
                OneCommandGenerator monOneCommand = new OneCommandGenerator("Mods de Lurius", "Voici un No mod", 3, 3);

                List<string> loopCommand = new List<string>();
                loopCommand.Add("say hello");
                Console.WriteLine($"[Info]{monOneCommand.OneCommandBuild(null ,loopCommand)}");
                Console.WriteLine("[# 3 SUCCESS]");
            }
            catch (Exception ex) { Console.WriteLine("[#1 ERROR]" + ex.Message); }

            // TEST WITHOUT INIT
            try
            {
                Console.WriteLine("[#2 TesteBuildInit]");
                OneCommandGenerator monOneCommand = new OneCommandGenerator("Mods de Lurius", "Voici un No mod", 3, 3);

                List<string> loopCommand = new List<string>();
                Console.WriteLine($"[Info]{monOneCommand.OneCommandBuild()}");
                Console.WriteLine("[#4 ERROR]");
            }
            catch (Exception ex) { Console.WriteLine("[#4 SUCCESS]" + ex.Message); }
        }

    }
}
