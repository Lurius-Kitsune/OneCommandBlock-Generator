using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCommandBlock_Generator
{
    internal class Generator
    {
        private string name;
        private string description;
        private List<string> one_command = new List<string>();

        public Generator(string name, string description)
        {
            this.name = name;
            this.description = description;
            this.one_command.Append("summon falling_block ~ ~5 ~ {{BlockState:{{Name:stone}},Time:1b," +
                $"Passengers:[{{id:\"minecraft:falling_block\",Time:0," +
                $"Passengers:[{{id:\"minecraft:falling_block\",Time:1b,BlockState:{{Name:redstone_block}}," +
                $"Passengers:[{{id:\"minecraft:falling_block\",Time:0," +
                $"Passengers:[{{id:\"minecraft:falling_block\",BlockState:{{Name:activator_rail}},Time:1b,Passengers:[");

        }

        public string Build(Array setupListCommand, Array loopListCommand)
        {

        }

        private List<string> SetSetupCommand(Array setupListCommand)
        {

        }
    }
}
