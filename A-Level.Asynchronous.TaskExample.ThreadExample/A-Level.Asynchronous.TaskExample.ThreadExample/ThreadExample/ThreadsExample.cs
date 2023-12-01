﻿namespace A_Level.Asynchronous.TaskExample.ThreadExample.ThreadExample;

internal sealed class ThreadsExample
{
    public static void CurrentThread()
    {
        Thread current = Thread.CurrentThread;

        Console.WriteLine($"ManagedThreadId: {current.ManagedThreadId}");
        Thread.Sleep(1000);

        Console.WriteLine($"Priority: {current.Priority}");
        Thread.Sleep(300);

        Console.WriteLine($"Name: {current.Name}");
        Thread.Sleep(1000);

        Console.WriteLine($"Name {current.ThreadState}");
        Thread.Sleep(2000);

        Console.WriteLine($"Alive {current.IsAlive}");

        current.Join(); // Just For Fun.
    }

    public static void ThreadExample()
    {
        Console.WriteLine($"ThreadsExample.ThreadMethod -> Current Thread: {Thread.CurrentThread.ManagedThreadId}");
        var thread = new Thread(ThreadMethod);
        //thread.Priority = ThreadPriority.Highest;
        Thread.Sleep(1000);
        thread.IsBackground = false;
        thread.Start();
    }

    public static void ThreadMethod()
    {
        Console.WriteLine($"ThreadsExample.ThreadMethod -> Current Thread: {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(3000);
        Console.WriteLine("Something");
    }

    public static void TimerExample()
    {
        int num = 0;
        TimerCallback tm = new TimerCallback(Count);
        Timer timer = new Timer(tm, num, 0, 2000);

        static void Count(object obj)
        {
            int x = (int)obj;

            for (int i = 1; i < 9; i++, x++)
            {
                Console.WriteLine($"{x * i}");
            }
        }
    }

    public static void ThreadQueue()
    {
        foreach (var number in Enumerable.Range(1, 40))
        {
            ThreadPool.QueueUserWorkItem((state) =>
            {
                Thread.Sleep(30);
                Console.WriteLine($"ThreadQueue with QueueUserWorkItem Id: {Thread.CurrentThread.ManagedThreadId}");
            });
        }
    }
}

