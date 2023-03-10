using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCommandBlock_Generator
{
    class Application
    {
        private string v = "1.19-.0.1";
        private string vType = "Bêta";
        static void Main(string[] args)
        {
            try
            {
                string answer = "0";
                Dictionary<string, bool> loopList = new Dictionary<string, bool>();
                List<string> initList = new List<string>();
                Application app = new Application();

                Introduction(app.v, app.vType);

                Console.WriteLine("Do you want an init step in you're no-mod?");
                Console.WriteLine("1. Yes       2. No");
                while (answer != "1" && answer != "2")
                {
                    answer = Console.ReadLine();
                    if (answer == "1")
                    {
                        AddCommand(ref initList);
                    }
                    else if (answer != "2")
                    {
                        Console.WriteLine("[Warning] Please choose an option");
                        Console.WriteLine("1. Yes       2. No");
                    }
                }
                Console.WriteLine("Add you're loop command for the no-mod :");
                AddCommand(ref loopList);
                OneCommandGenerator oneCommand = new OneCommandGenerator("Lurius", "Test", 5, 5);
                try
                {
                    string fileName = @"./onecommand.txt";
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                    using (FileStream file = File.Create(fileName))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(oneCommand.OneCommandBuild(loopList, initList));
                        // Add some information to the file.
                        file.Write(info, 0, info.Length);
                        fileName = file.Name;
                    }
                    Console.WriteLine("[Sucess] End of programme, File create in :");
                    Console.WriteLine(fileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[Erreur] Can't create the file");
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("====================Erreur=======================");
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine("Please make a ticket on github or contact Lurius on discord : Lurius#2569 ");
            }
        }

        private static void Introduction(string v, string vType)
        {
            Console.WriteLine($"Welcolme ! Command Generator {v} {vType}");
            Console.WriteLine($"Made by LuriusFox");
            Console.WriteLine($"Contact :");
            Console.WriteLine($"Twitter : @Lurius_the_fox");
            Console.WriteLine($"Twitch : LuriusFox");
            Console.WriteLine($"[WARNING !] This app is free and you dont need to pay for it !");
        }

        private static void AddCommand(ref List<string> listX)
        {
            bool stop = false;
            string command = "", answer = "";
            int i = 1;
            while (!stop)
            {
                Console.WriteLine($"Command n°{i} : ");
                command = Console.ReadLine();
                if (command is not null)
                {
                    listX.Add(command);
                    i++;
                    Console.WriteLine("Continue? ? [Yes] or [No]");
                    do
                    {
                        answer = Console.ReadLine();
                        if (answer is not null)
                        {
                            if (answer.ToLower() == "no")
                            {
                                stop = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("[Warning] Please choose an option");
                        }
                    } while (answer.ToLower() != "yes" && answer.ToLower() == "no");
                }
                else
                {
                    Console.WriteLine("[Warning] Please choose an option");
                }
            }
        }

        private static void AddCommand(ref Dictionary<string, bool> listX)
        {
            bool stop = false, cond = false;
            string command = "", answer = "";
            int i = 1;
            while (!stop)
            {
                Console.WriteLine($"Command n°{i} : ");
                command = Console.ReadLine();
                if (command is not null)
                {
                    Console.WriteLine("Conditionnal ?: true or false");
                    do
                    {
                        answer= Console.ReadLine();
                        if (answer is not null)
                        {
                            if (answer.ToLower() == "true")
                            {
                                cond = true;
                            }
                            else if (answer.ToLower() == "false")
                            {
                                cond = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("[Warning] Please choose an option");
                        }
                    } while (answer != "true" && answer != "false");
                    listX.Add(command, cond);
                    i++;
                    Console.WriteLine("Continue? ? [Yes] or [No]");
                    do
                    {
                        answer = Console.ReadLine();
                        if (answer is not null)
                        {
                            if (answer.ToLower() == "no")
                            {
                                stop = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("[Warning] Please choose an option");
                        }
                    } while (answer.ToLower() != "yes" && answer.ToLower() != "no");
                }
                else
                {
                    Console.WriteLine("[Warning] Please write a command");
                }
            }
        }
    }
}