using OneCommandBlock_Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCommandBlock_Generator.Test
{
    class TestGenerator
    {
        static void Main(string[] args)
        {
            //TesteBuildInitOnly();
            TesteBuildLoopOnly();
            Console.ReadKey();
        }

        /// <summary>
        /// Testing if the no-mod is build without the need of a loop command
        /// </summary>
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

        /// <summary>
        /// Testing if the no-mod is build without the need of a init command
        /// </summary>
        public static void TesteBuildLoopOnly()
        {
            //TESTE SI INIT ET MIT
            try
            {
                Console.WriteLine("[#3 TesteBuildLoop]");
                OneCommandGenerator monOneCommand = new OneCommandGenerator("Mods de Lurius", "Voici un No mod", 4, 4);

                Dictionary<string, bool> loopCommand = new Dictionary<string, bool>();
                loopCommand.Add("scoreboard players set @e[type=item, nbt={Item:{id:\"minecraft:grass_block\"},OnGround:1b}] 63J9tq_I 3", false);
                loopCommand.Add("scoreboard players set @e[type=item, nbt={Item:{id:\"minecraft:stone\"},OnGround:1b}] 63J9tq_I 4", false);
                loopCommand.Add("execute at @e[scores={63J9tq_I=3}] if entity @e[scores={63J9tq_I=4},distance=..1] run summon item ~ ~0.5 ~ {Item:{id:\"minecraft:diamond_sword\",Damage:10,Count:1}}", false);
                loopCommand.Add("execute at @e[scores={63J9tq_I=3}] run particle minecraft:firework ~ ~ ~ 0.1 0.1 0.1 0.1 100", true);
                loopCommand.Add("kill @e[scores={63J9tq_I=3}]", true);
                loopCommand.Add("kill @e[scores={63J9tq_I=4}]", true);
                Console.WriteLine($"[Info]{monOneCommand.OneCommandBuild(null, loopCommand)}");
                Console.WriteLine("[# 3 SUCCESS]");
            }
            catch (Exception ex) { Console.WriteLine("[#1 ERROR]" + ex.Message); }

            // TEST WITHOUT INIT
            try
            {
                Console.WriteLine("[#4 TesteBuildLoop]");
                OneCommandGenerator monOneCommand = new OneCommandGenerator("Mods de Lurius", "Voici un No mod", 5, 3);

                Dictionary<string, bool> loopCommand = new Dictionary<string, bool>();
                Console.WriteLine($"[Info]{monOneCommand.OneCommandBuild()}");
                Console.WriteLine("[#4 ERROR]");
            }
            catch (Exception ex) { Console.WriteLine("[#4 SUCCESS]" + ex.Message); }
        }

    }
}
