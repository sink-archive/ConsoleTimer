using System;
using System.Collections.Generic;
using System.Media;
using System.Reflection;

namespace ConsoleTimer
{
    class chime
    {
        public static string name;
        public static string path;

        public chime(string _name, string _path)
        {
            name = _name;
            path = _path;
        }
    } // Add custom type

    class MainClass
    {
        // Declare things for audio chime stuffs
        List<chime> audioChimes = new List<chime>() { new chime("Alarm 1", "alarm1.wav") };

        public static void Main(string[] args)
        {
        restart:;
            Console.Write("Would you like to countdown [down] or count up [up]?");
            var upOrDown = Console.ReadLine();

            switch (upOrDown.ToLower())
            {
                case "up":
                    countUp();
                    break;
                case "down":
                    Console.Write("How many hours would you like to count down for?");
                    int hours = Convert.ToInt32(Console.ReadLine());
                    Console.Write("How many minutes would you like to count down for?");
                    int minutes = Convert.ToInt32(Console.ReadLine());
                    Console.Write("How many seconds would you like to count down for?");
                    float seconds = (float)Convert.ToDouble(Console.ReadLine());

                    countDown(hours, minutes, seconds);
                    break;
                default:
                    Console.Clear();
                    goto restart;
            }
        }

        private static void countUp()
        {
            float secondsRaw = 0;
            float secondsProcessed = 0;
            int minutes = 0;
            int hours = 0;

            while (true)
            {
                ProcessTime(secondsRaw,
                    out hours,
                    out minutes,
                    out secondsProcessed);
                Console.Clear();
                Console.WriteLine($"{hours}:{minutes}:{secondsProcessed}");
                secondsRaw += 0.1f;
                secondsRaw = (float)Math.Round(secondsRaw, 1);
                System.Threading.Thread.Sleep(100);
            }
        }

        private static void ProcessTime(float secondsIn, out int hoursOut, out int minutesOut, out float secondsOut)
        {
            hoursOut = (int)Math.Floor(secondsIn / 3600);
            minutesOut = (int)Math.Floor(secondsIn % 3600 / 60);
            secondsOut = (float)Math.Round(secondsIn % 3600 % 60, 1);
        }

        private static void countDown(long targetHours, int targetMinutes, float targetSeconds)
        {
            float secondsRaw = targetSeconds + targetMinutes *  60 + targetHours * 3600;
            float secondsProcessed = 0;
            int minutes = 0;
            int hours = 0;

            while (secondsRaw != 0)
            {
                ProcessTime(secondsRaw,
                    out hours,
                    out minutes,
                    out secondsProcessed);
                Console.Clear();
                Console.WriteLine($"{hours}:{minutes}:{secondsProcessed}");
                secondsRaw -= 0.1f;
                secondsRaw = (float)Math.Round(secondsRaw, 1);
                System.Threading.Thread.Sleep(100);
            }
            Console.Clear();
            Console.Write("Your countdown timer has ended. Would you like to use the timer again [y/n]?");
            string yesOrNo = Console.ReadLine();
            Console.Clear();
            if (yesOrNo.ToLower() == "y")
            {
                Main(new string[0]);
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void ConfigureChimes()
        {

        }

        private void PlayChime(string pathToChime)
        {
            SoundPlayer chimePlayer;
            Assembly assembly;
            assembly = Assembly.GetExecutingAssembly();
            chimePlayer = new SoundPlayer(assembly.GetManifestResourceStream(Environment.CurrentDirectory + "/" + pathToChime));
        }
    }
}
