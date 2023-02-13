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
        private List<string> oneCommand = new List<string>();

        public Generator(string name, string description)
        {
            this.name = name;
            this.description = description;
            this.oneCommand.Add($"summon falling_block ~ ~5 ~ {{BlockState:{{Name:redstone_block}}," +
                $"Passengers:[{{id:\"minecraft:armor_stand\",Health:0," +
                $"Passengers:[{{id:falling_block,BlockState:{{Name:activator_rail}}," +
                $"Passengers:[{{id:command_block_minecart,Command:'gamerule commandBlockOutput false'}}," +
                $"{{id:command_block_minecart,Command:'data merge block ~ ~-2 ~ {{auto:0}}'}},");

        }

        public string OneCommandBuild(List<string>? initListCommand = null, List<string>? loopListCommand = null)
        {
            string oneCommandString;
            if (initListCommand != null)
            {
                InitCommand.InitBuild(initListCommand, ref this.oneCommand);
            }
            if (this.oneCommand.Count == 1)
            {
                throw new Exception("Veuillez mettre une commande init ou Loop");
            }
            EndGenerator();
            oneCommandString = String.Join(" ", this.oneCommand);
            return oneCommandString;
        }

        private void EndGenerator()
        {
            this.oneCommand.Add($"{{id:command_block_minecart,Command:'setblock ~ ~1 ~ command_block{{auto:1,Command:\"fill ~ ~ ~ ~ ~-2 ~ air\"}}'}}," +
                $"{{id:command_block_minecart,Command:'kill @e[type=command_block_minecart,distance=..1]'}}]}}]}}]}}");
        }
    }
}
