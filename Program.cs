using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

// Increase internal for faster playback.
const int FrameInterval = 30;
StringBuilder _buffer = new();

using (var fileStream = File.OpenText(@"sw1.txt"))
{
    while (fileStream is { EndOfStream: false })
    {
        await ShowFramesAsync(fileStream); 
    }
}

Console.Clear();
Console.SetCursorPosition(0, 0);
Console.WriteLine("    The end...");

async Task ShowFramesAsync(StreamReader stream)
{
    _buffer.Clear();

    var frameCount = decimal.Parse(stream.ReadLine());

    for (var i = 0; i < 13 /* rows to read */; i++)
    {
        _buffer.AppendLine(stream.ReadLine());
    }

    Console.Clear();
    Console.SetCursorPosition(0, 0);
    Console.Write(_buffer.ToString());

    var framesInTick = Convert.ToInt64(frameCount / FrameInterval * TimeSpan.TicksPerSecond);
    await Task.Delay(TimeSpan.FromTicks(framesInTick));
}
