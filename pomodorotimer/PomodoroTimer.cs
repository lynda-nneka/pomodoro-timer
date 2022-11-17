using System;
using Timer = System.Timers;

public class PomodoroTimer
{
    public int totalWorkTimeInSeconds = 1 * 60;
    public int totalRestTimeInSeconds = 1 * 60;
    public Timer.Timer mainTimer = new Timer.Timer();
    public Timer.Timer restTimer = new Timer.Timer();

    public void Run()
    {
        Console.WriteLine("What task do you want to work on");

        string userTask = Console.ReadLine();

        SetupTimer();
        StartWorkTimer();

    }

    private void SetupTimer()
    {
        mainTimer.Interval = 1000;
        mainTimer.Elapsed += OnWorkTimerElapsedEvent;

        restTimer.Interval = 1000;
        restTimer.Elapsed += OnRestTimerElapsedEvent;
    }

    private void StartWorkTimer()
    {

        mainTimer.Start();

    }

    private void StartRestTimer()
    {
        Console.WriteLine("Take a short break (5 minutes)");
        restTimer.Start();
    }

    private void ResetTimer()
    {
        totalWorkTimeInSeconds = 1 * 60;
        totalRestTimeInSeconds = 1 * 60;

        mainTimer.Start();
    }

    private void OnWorkTimerElapsedEvent(Object source, Timer.ElapsedEventArgs e)
    {
        totalWorkTimeInSeconds--;
        TimeSpan time = TimeSpan.FromSeconds(totalWorkTimeInSeconds);
        string timeMessage = time.ToString(@"mm\:ss");

        Console.WriteLine("Work Time Remaining " + timeMessage);

        if (totalWorkTimeInSeconds <= 0)
        {
            mainTimer.Stop();
            Console.WriteLine("Time is up!");
            StartRestTimer();
        }
    }

    private void OnRestTimerElapsedEvent(Object source, Timer.ElapsedEventArgs e)
    {
        totalRestTimeInSeconds--;
        Console.WriteLine("Rest Time Passed " + totalRestTimeInSeconds);

        if (totalRestTimeInSeconds <= 0)
        {
            restTimer.Stop();
            Console.WriteLine("Rest Time is up!");
            ResetTimer();
        }
    }
}

