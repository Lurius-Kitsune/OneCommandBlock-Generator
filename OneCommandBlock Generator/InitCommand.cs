using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCommandBlock_Generator
{
    public abstract class InitCommand
    {
        public static void InitBuild(List<string> initListCommand, ref List<string> oneCommand)
        {
            try
            {
                if (initListCommand.Count == 0) { throw new Exception("Aucune commande d'initiation mit"); }
                for (int i = 0; i == initListCommand.Count; i++)
                {
                    oneCommand.Add($"{{ id:\"minecraft:command_block_minecart\",Command:\"{initListCommand[i]}\"}}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
