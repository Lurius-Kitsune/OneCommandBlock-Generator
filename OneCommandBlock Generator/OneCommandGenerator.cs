﻿using System;
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

        private void StructureBuild()
        {
            for(int i = 0; i != this.largeur; i++)
            {
                for(int j = 0; i!= this.longueur; j++)
                {
                    this.oneCommand.Add($"{{id:command_block_minecart,Command:'setblock ~ ~ ~ minecraft:stone'}},");
                }
            }
        }
    }
}