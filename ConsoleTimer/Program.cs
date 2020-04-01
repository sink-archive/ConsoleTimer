using System;
using System.Collections.Generic;
using System.Media;
using System.Reflection;

namespace ConsoleTimer
{
    public class chime
    {
        public string name;
        public string path;

        public chime(string _name, string _path)
        {
            name = _name;
            path = _path;
        }
    } // Add custom type

    class MainClass
    {
        // Declare things for audio chime stuffs
        static List<chime> audioChimes = new List<chime>() { new chime("Alarm 1", "alarm1.wav") };
        public static short preferredChimeIndex = 0;

        public static void Main(string[] args)
        {
        restart:;
            Console.Clear();
            Console.Write("Would you like to countdown [down], count up [up], or configure audio chimes [chime] [up|down|chime]?");
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
                case "chime":
                    ConfigureChimes();
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

        private static void ConfigureChimes()
        {
        notHappyWithChime:;
            Console.Clear();
            Console.Write("What chime would you like to use [use numbers starting with 0 to choose]?");
            preferredChimeIndex = Convert.ToInt16(Console.ReadLine());
            if (preferredChimeIndex > audioChimes.Count - 1)
            {
                Console.WriteLine("That is not a valid chime number");
                System.Threading.Thread.Sleep(500);
                goto notHappyWithChime;
            }

            PlayChime(audioChimes[preferredChimeIndex].path);
            Console.Write("Are you happy with this chime [y|n]?");
            if (Console.ReadLine().ToLower() == "y")
            {
                Main(new string[0]);
            }
            else
            {
                goto notHappyWithChime;
            }
        }

        private static void PlayChime(string pathToChime)
        {
            SoundPlayer chimePlayer;
            Assembly assembly;
            assembly = Assembly.GetExecutingAssembly();
            chimePlayer = new SoundPlayer(assembly.GetManifestResourceStream(Environment.CurrentDirectory + "/" + pathToChime));
            chimePlayer.Play();
        }
    }
}
