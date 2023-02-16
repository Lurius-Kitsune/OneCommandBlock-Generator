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
        public OneCommandGenerator(string name, string description, int longueur, int largeur)
        {
            this.name = name;
            this.description = description;
            this.longueur = longueur;
            this.largeur = largeur;
            this.hauteur = 3;
            this.oneCommand.Add($"summon falling_block ~ ~5 ~ {{BlockState:{{Name:redstone_block}}," +
                $"Passengers:[{{id:\"minecraft:armor_stand\",Health:0," +
                $"Passengers:[{{id:falling_block,BlockState:{{Name:activator_rail}}," +
                $"Passengers:[{{id:command_block_minecart,Command:'gamerule commandBlockOutput false'}}," +
                $"{{id:command_block_minecart,Command:'data merge block ~ ~-2 ~ {{auto:0}}'}},");

        }

        /// <summary>
        /// Generate the OneCommand string
        /// </summary>
        /// <param name="initListCommand">List of command when first start</param>
        /// <param name="loopListCommand">List of action that are loop</param>
        /// <returns>OneCommand String</returns>
        /// <exception cref="Exception"></exception>
        public string OneCommandBuild(List<string>? initListCommand = null, Dictionary<string, bool>? loopListCommand = null)
        {
            string oneCommandString;
            if (initListCommand != null)
            {
                InitBuild(initListCommand);
            }
            if (loopListCommand != null)
            {
                LoopBuild(loopListCommand);
            }
            if (this.oneCommand.Count == 1)
            {
                throw new Exception("Veuillez mettre une commande init ou Loop");
            }
            //StructureBuild();
            this.oneCommand.Add($"{{id:command_block_minecart,Command:'setblock ~ ~1 ~ command_block{{auto:1,Command:\"fill ~ ~ ~ ~ ~-2 ~ air\"}}'}}," +
                $"{{id:command_block_minecart,Command:'kill @e[type=command_block_minecart,distance=..1]'}}]}}]}}]}}");
            oneCommandString = String.Join(" ", this.oneCommand);
            return oneCommandString;
        }

        /// <summary>
        /// With the list of command, add this to list of One Command
        /// This wiill make the startup of you're no-mod
        /// </summary>
        /// <param name="initListCommand">List of command when first start</param>
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

        /// <summary>
        /// With the list of command, add this to list of One Command
        /// This wiill make the Loop of you're no-mod
        /// </summary>
        /// <param name="loopListCommand">List of action that are loop</param>
        private void LoopBuild(Dictionary<string, bool> loopListCommand)
        {
            try
            {
                int cptLongueur = 1, cptHauteur = 0, cptLargeur = 1;
                string faces = "east";
                bool firstLoop = false, invert = false;
                foreach (KeyValuePair<string, bool> command in loopListCommand)
                {
                    if ((cptLongueur == this.longueur - 2 && !invert) ||
                        (cptLongueur == 2 && invert)) { faces = "south"; }
                    else if ((cptLongueur == this.longueur - 1 && !invert) || 
                        (cptLongueur == 1 && invert))
                    {
                        cptLargeur++;
                        switch(invert){
                            default:
                                cptLongueur = this.longueur - 2;
                                invert = true;
                            break;

                            case true:
                                cptLongueur = 1;
                                invert = false;
                                break;
                        }
                        if (cptLargeur == this.largeur - 1)
                        {
                            faces = "up";
                        }
                    }
                    if (!firstLoop)
                    {
                        this.oneCommand.Add($"{{id:command_block_minecart,Command:'setblock ~{cptLongueur + 1} ~{cptHauteur} ~{cptLargeur} " +
                                            $"repeating_command_block[facing={faces}]{{auto:1,Command:\"{command.Key}\"}}'}},");
                        firstLoop = true;
                    }
                    else
                    {
                        switch (faces)
                        {
                            default:
                                this.oneCommand.Add($"{{id:command_block_minecart,Command:'setblock ~{cptLongueur + 1} ~{cptHauteur} ~{cptLargeur} " +
                                            $"chain_command_block[facing={faces}, conditional={command.Value.ToString().ToLower()}]{{auto:1,Command:\"{command.Key}\"}}'}},");
                                break;

                            case "south":
                                this.oneCommand.Add($"{{id:command_block_minecart,Command:'setblock ~{cptLongueur + 1} ~{cptHauteur} ~{cptLargeur} " +
                                            $"chain_command_block[facing={faces}, conditional={command.Value.ToString().ToLower()}]{{auto:1,Command:\"{command.Key}\"}}'}},");
                                if (cptLargeur % 2 == 0)
                                {
                                    faces = "east";
                                }
                                else
                                {
                                    faces = "west";
                                }
                                break;
                            case "up":
                                this.oneCommand.Add($"{{id:command_block_minecart,Command:'setblock ~{cptLongueur + 1} ~{cptHauteur} ~{cptLargeur-1} " +
                                           $"chain_command_block[facing={faces}, conditional={command.Value.ToString().ToLower()}]{{auto:1,Command:\"{command.Key}\"}}'}},");
                                this.hauteur++;
                                cptHauteur++;
                                cptLargeur = 1;
                                break;
                        }
                    }
                    if (!invert) { cptLongueur++; }
                    else { cptLongueur--; }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// Generate the string added to the List, 
        /// It will make the structur surronding our command block.
        /// </summary>
        private void StructureBuild()
        {
            // High
            for (int h = 0; h < this.hauteur; h++)
            {
                //
                for (int i = 0; i < this.largeur; i++)
                {
                    //Lengh
                    for (int j = 0; j < this.longueur; j++)
                    {
                        if (h != 0 && h != this.hauteur - 1 &&
                           (i == 0 || i == this.largeur - 1 ||
                           ((i != 0 || i != this.largeur - 1) && (j == 0 || j == this.longueur - 1))))
                        {
                            this.oneCommand.Add($"{{id:command_block_minecart,Command:'setblock ~{j + 1} ~{h - 1} ~{i} minecraft:glass'}},");
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
