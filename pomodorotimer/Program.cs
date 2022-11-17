using System;
using Timer = System.Timers;

public class Program
{
    public static int totalWorkTimeInSeconds = 25 * 60;
    public static int totalRestTimeInSeconds = 5 * 60;
    public static Timer.Timer mainTimer = new Timer.Timer();
    public static Timer.Timer restTimer = new Timer.Timer();

    public static void Main()
    {
        Console.WriteLine("press Q to exit the program");

        PomodoroTimer pomodoroTimer = new PomodoroTimer();
        pomodoroTimer.Run();




        while (Console.ReadKey().Key != ConsoleKey.Q) { }
    }

}