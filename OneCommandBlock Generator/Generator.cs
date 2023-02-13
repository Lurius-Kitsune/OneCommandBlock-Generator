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
            this.oneCommand.Add("summon falling_block ~ ~5 ~ {{BlockState:{{Name:stone}},Time:1b," +
                $"Passengers:[{{id:\"minecraft:falling_block\",Time:0," +
                $"Passengers:[{{id:\"minecraft:falling_block\",Time:1b,BlockState:{{Name:redstone_block}}," +
                $"Passengers:[{{id:\"minecraft:falling_block\",Time:0," +
                $"Passengers:[{{id:\"minecraft:falling_block\",BlockState:{{Name:activator_rail}},Time:1b,Passengers:[");

        }

        public string OneCommandBuild(List<string>? initListCommand = null, List<string>? loopListCommand = null)
        {
            try
            {
                string oneCommandString;
                InitCommand.InitBuild(initListCommand, ref this.oneCommand);

                if (this.oneCommand.Count == 0)
                {
                    throw new Exception("Veuillez mettre une commande init ou Loop");
                }
                oneCommandString = String.Join(" ", this.oneCommand);
                return oneCommandString;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Erreur";
            }
        }
    }
}
