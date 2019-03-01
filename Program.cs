using System;
using System.IO;
using System.Threading;

namespace StarWars
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileStream = File.OpenText(@"sw1.txt");
            ShowFrames(fileStream);
        }
        static void ShowFrames(StreamReader stream)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            // Get the timing from the first line
            decimal frameCount = decimal.Parse(stream.ReadLine());
            string frame = string.Empty;

            for (int i = 0; i < 13; i++)
            {
                frame += stream.ReadLine() + "\r\n";
            }

            Console.Write(frame);
            long frameTimeInTicks = Convert.ToInt64(frameCount / 15 * TimeSpan.TicksPerSecond);
            Thread.Sleep(TimeSpan.FromTicks(frameTimeInTicks));

            ShowFrames(stream);
        }
    }
}
