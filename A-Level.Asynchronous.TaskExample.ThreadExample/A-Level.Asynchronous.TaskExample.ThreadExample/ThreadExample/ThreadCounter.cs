namespace A_Level.Asynchronous.TaskExample.ThreadExample.ThreadExample;

public static class ThreadCounter
{
    private static readonly object _locker = new object();

    //private static readonly string _locker2 = "1";
    //private static readonly Type _locker3 = typeof(ThreadCounter);

    private static int _value = 0;

    public static void LockExample()
    {
        var t1 = new Thread(() => Increment(false));
        var t2 = new Thread(() => Increment(true));

        t1.Start();
        t2.Start();

        //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

        t1.Join();
        t2.Join();

        Console.WriteLine("Final value: " + _value);
    }

    private static void Increment(bool isSleep)
    {
        lock (_locker)
        {
            for (int i = 0; i < 400; i++)
            {
                //try
                //{
                //    Monitor.Enter(_locker);
                //    _value++;
                //    if (isSleep)
                //    {
                //        Thread.Sleep(3);
                //    }
                //    Console.WriteLine($"ThreadCounter.Increment: {Thread.CurrentThread.ManagedThreadId} | Value: {_value}.");
                //}
                //finally
                //{
                //    Monitor.Exit(_locker);
                //}

                Interlocked.Increment(ref _value);
                if (isSleep)
                {
                }

                Console.WriteLine($"ThreadCounter.Increment: {Thread.CurrentThread.ManagedThreadId} | Value: {_value}.");
            }
        }
    }
}
