using System.Diagnostics;

namespace A_Level.Asynchronous.TaskExample.ThreadExample;

internal sealed class Program
{
    public static async Task Main(string[] args)
    {
        var result = await TasksExample.TaskCompletionSourceExampleAsync();
        //await TasksExample.TaskExampleAsync();

        //await TasksExample.TaskRun();
        //await TasksExample.TaskContinueWithRunAsync();

        //await TasksExample.DoubleAsyncExampleAsync();

        //Thread.Sleep(10000);

        //ThreadCounter.LockExample();

        //var thread = new Thread(Something);
        //thread.Start();

        //for (int i = 0; i < 20; i++)
        //{
        //    Console.WriteLine($"Current Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        //    Console.WriteLine(i * 2);
        //    Thread.Sleep(1000);
        //}


        //var processNode = Process.Start("node.exe");

        //ThreadsExample.CurrentThread();
        //ThreadsExample.ThreadExample();

        //ThreadsExample.TimerExample();
        //ThreadCounter.LockExample();
        //TasksExample.DoubleAsyncExampleAsync();
        //await TasksExample.ThreadExampleAsync();
        Console.WriteLine("End of program.");
    }

    public static void Something()
    {
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine($"Created Thread Current Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine(i * 5);
            Thread.Sleep(4000);
        }
    }
}
