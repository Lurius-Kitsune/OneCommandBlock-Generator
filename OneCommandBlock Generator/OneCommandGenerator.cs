using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCommandBlock_Generator
{
    internal class OneCommandGenerator
    {
        private string name;
        private string description;
        private int longueur;
        private int largeur;
        private int hauteur;
        private List<string> oneCommand = new List<string>();

        /// <summary>
        /// Construct One Command Compiler
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="longueur"></param>
        /// <param name="largeur"></param>
        public OneCommandGenerator(string name, string description, int longueur)
        {
            this.name = name;
            this.description = description;
            this.longueur = longueur;
            this.largeur = 3;
            this.hauteur = 3;
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
                InitBuild(initListCommand);
            }
            if (this.oneCommand.Count == 1)
            {
                throw new Exception("Veuillez mettre une commande init ou Loop");
            }
            StructureBuild();
            this.oneCommand.Add($"{{id:command_block_minecart,Command:'setblock ~ ~1 ~ command_block{{auto:1,Command:\"fill ~ ~ ~ ~ ~-2 ~ air\"}}'}}," +
                $"{{id:command_block_minecart,Command:'kill @e[type=command_block_minecart,distance=..1]'}}]}}]}}]}}");
            oneCommandString = String.Join(" ", this.oneCommand);
            return oneCommandString;
        }

        public void InitBuild(List<string> initListCommand)
        {
            try
            {
                if (initListCommand.Count == 0) { throw new Exception("Aucune commande d'initiation mit"); }
                for (int i = 0; i != initListCommand.Count; i++)
                {
                    this.oneCommand.Add($"{{ id:\"minecraft:command_block_minecart\",Command:\"{initListCommand[i]}\"}},");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void LoopBuild(List<string> loopListCommand)
        {
            int cptLongueur = 1;
            int cptLargeur = 1;
            cptLongueur++;
            if (cptLongueur == this.longueur)
            {
                cptLargeur++;
                cptLongueur = 1;
                if (cptLargeur == this.largeur)
                {
                    this.hauteur++;
                    cptLargeur = 1;
                }
            }
        }

        private void StructureBuild()
        {
            for (int h = 0; h < this.hauteur; h++)
            {
                for (int i = 0; i < this.largeur; i++)
                {
                    for (int j = 0; j < this.longueur; j++)
                    {
                        if ((h != 0 && h != this.hauteur-1) && 
                           (i== 0 || i== this.largeur) || 
                           (i != 0 || i != this.largeur) && (j == 0 || j == this.longueur))
                        {
                            this.oneCommand.Add($"{{id:command_block_minecart,Command:'setblock ~{j + 1} ~{h - 1} ~{i} minecraft:grass_block'}},");
                        }
                        else if (h == 0 || h == this.hauteur - 1)
                        {
                            this.oneCommand.Add($"{{id:command_block_minecart,Command:'setblock ~{j + 1} ~{h - 1} ~{i} minecraft:stone'}},");
                        }
                    }
                }
            }
        }
    }
}
