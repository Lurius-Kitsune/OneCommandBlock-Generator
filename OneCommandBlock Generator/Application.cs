using System;
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
            Application app = new Application();
            Introduction(app.v, app.vType);

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
    }
}