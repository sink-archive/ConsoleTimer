using System;

namespace ConsoleTimer
{
    class MainClass
    {
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

        }
    }
}
