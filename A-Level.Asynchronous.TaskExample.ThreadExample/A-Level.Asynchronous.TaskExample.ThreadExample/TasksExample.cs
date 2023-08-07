namespace A_Level.Asynchronous.TaskExample.ThreadExample;

internal class TasksExample
{
    public static async Task TaskExampleAsync()
    {
        Console.WriteLine($"Begin: Thread Id {Thread.CurrentThread.ManagedThreadId}.");

        var task = new Task(async () =>
        {
            ConsoleSwitch.SwitchTo(ConsoleColor.Red, () => Console.WriteLine($"Before: Thread Id in Lambda: {Thread.CurrentThread.ManagedThreadId}."));
            await Task.Delay(2000);
            ConsoleSwitch.SwitchTo(ConsoleColor.Red, () => Console.WriteLine($"After: Thread Id in Lambda: {Thread.CurrentThread.ManagedThreadId}."));
        });
 
        task.Start();

        Console.WriteLine($"Before await: Thread Id {Thread.CurrentThread.ManagedThreadId}.");

        await task;

        await Task.Delay(1000);

        Console.WriteLine($"End await: Thread Id {Thread.CurrentThread.ManagedThreadId}.");
    }

    public static Task<string[]> ReadFromFileAsync()
    {
        var reader = new StreamReader("file-example.txt");

        return Task.Run(async () =>
        {
            var list = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();

                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                await Task.Delay(500);

                foreach (var item in line.Split(' '))
                {
                    Console.WriteLine($"-Item {item}-");
                }
                list.Add(line);
            }
            return list.ToArray();
        });
    }

    public static Task<int> TaskCompletionSourceExampleAsync()
    {
        var completionSource = new TaskCompletionSource<int>();

        Console.CancelKeyPress += (o, ev) =>
        {
            Console.WriteLine("Click Ctrl + C");
            completionSource.SetResult(10);
        };

        return completionSource.Task;
    }

    public static async Task WriteToConsoleAsync()
    {
        Console.WriteLine("Write Something.");
        await Task.Delay(1000);
        Console.WriteLine("Write Something more and more.");
    }

    public static async Task DoubleAsyncExampleAsync()
    {
        string[] lines = await ReadFromFileAsync();
        await WriteToConsoleAsync();

        //var taskRead = ReadFromFileAsync();
        //var taskConsole = WriteToConsoleAsync();

        //await Task.WhenAll(taskRead, taskConsole);
        //string[] linesResult = taskRead.Result;
    }

    public static Task TaskRun()
    {
        Task<int> task = Task.Run(async () => {
            await Task.Delay(2000);
            return 111;
        });

        task.ContinueWith(t => {
            ConsoleSwitch.SwitchTo(ConsoleColor.Red, () => Console.WriteLine($"TaskRun: Thread Id in Lambda: {Thread.CurrentThread.ManagedThreadId}."));
            Console.WriteLine("TaskRun: Task completed with result: " + t.Result);
        });

        return task;
    }

    public static async Task TaskContinueWithRunAsync()
    {
        Task<int> task = Task.Run(async () => {
            await Task.Delay(2000);
            return 999;
        });

        int result = await task;
        Console.WriteLine("TaskContinueWithRunAsync: Task completed with result: " + result);
    }
}
