using System.Diagnostics;
using A_Level.Asynchronous.TaskExample.ThreadExample.TaskExample;

namespace A_Level.Asynchronous.TaskExample.ThreadExample;

internal sealed class Program
{
    
    public static int DoWork()
    {
        Console.WriteLine($"Thread 2 Id: {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine("Started...");
        Thread.Sleep(4000);
        Console.WriteLine("Ended...");
        return 255;
    }

    public static async Task WriteLinesAsync()
    {
        using (var writer = new StreamWriter("text.txt"))
        {
            var t1 = writer.WriteLineAsync("123");
            var t2 = writer.WriteLineAsync("456 ---------");
            var t3 = writer.WriteLineAsync("--------- 789");
            var t4 = writer.WriteLineAsync("---------  101112");

            await Task.WhenAll(t1, t2, t3, t4);
        }
    }

    public static async Task Main(string[] args)
    {
        await WriteLinesAsync();

        string[] lines = await TasksExample.ReadFromFileAsync();

        //Console.WriteLine($"Thread 1 Id: {Thread.CurrentThread.ManagedThreadId}");


        //Task<int> task = Task.Run(() =>
        //{
        //    // 2
        //    return DoWork();
        //});

        //await task;

        Console.Read();
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
