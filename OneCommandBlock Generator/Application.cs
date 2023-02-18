﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCommandBlock_Generator
{
    class Application
    {
        private double v = 0.1;
        private string vType = "Bêta";
        static void Main(string[] args)
        {
            string answer = "0";
            List<string> loopList = new List<string>();
            List<string> initList = new List<string>();
            Application app = new Application();

            Introduction(app.v, app.vType);

            Console.WriteLine("Do you want an init step in you're no-mod?");
            Console.WriteLine("1. Yes       2. No");
            while (answer != "1" || answer != "2")
                if (answer == "1")
                {
                    AddCommand(ref initList);
                }
                else if (answer != "2")
                {
                    Console.WriteLine("[Warning] Please choose an option");
                    Console.WriteLine("1. Yes       2. No");
                }
            Console.WriteLine("Add you're loop command for the no-mod :");
            AddCommand(ref loopList);
            OneCommandGenerator oneCommand = new OneCommandGenerator("Lurius", "Test", 5, 5);
            oneCommand.OneCommandBuild(loopList, initList)
        }

        private static void Introduction(double v, string vType)
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
                do
                {
                    if (command is not null)
                    {
                        listX.Add(command);
                        i++;
                        Console.WriteLine("Continue? ? [Yes] or [No]");
                        answer = Console.ReadLine();
                        do
                        {
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
                        } while (answer is null);
                    }
                    else
                    {
                        Console.WriteLine("[Warning] Please choose an option");
                    }
                } while (command is null);
            }
        }

        private static void AddCommand(ref Dictionary<string,bool> listX)
        {
            bool stop = false, cond = false;
            string command = "", answer = "";
            int i = 1;
            while (!stop)
            {
                Console.WriteLine($"Command n°{i} : ");
                command = Console.ReadLine();
                do
                {
                    if (command is not null)
                    {
                        Console.WriteLine("Conditionnal ?: true or false");
                        do
                        {
                            if (answer is not null)
                            {
                                if (answer.ToLower() == "true")
                                {
                                    cond = true;
                                }
                                else if (answer.ToLower() == "false"){
                                    cond = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("[Warning] Please choose an option");
                            }
                        } while (answer is null);
                        listX.Add(command, cond);
                        i++;
                        Console.WriteLine("Continue? ? [Yes] or [No]");
                        answer = Console.ReadLine();
                        do
                        {
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
                        } while (answer is null);
                    }
                    else
                    {
                        Console.WriteLine("[Warning] Please choose an option");
                    }
                } while (command is null);
            }
        }
    }
}